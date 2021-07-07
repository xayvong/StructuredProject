using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
using CKK.Logic.Models;
using CKK.Persistance.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CKK.Persistance.Models
{
    public class FileStore : IStore, ILoadable, ISavable
    {
        private List<StoreItem> Items;
        private readonly string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance" + Path.DirectorySeparatorChar + "StoreItems.dat";
        private int IdCounter = 0;

        public FileStore()
        {
            CreatePath();
            Items = new();
            Load();
        }


        public StoreItem AddStoreItem(Product product, int quantity)
        {
            if (quantity < 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            if (product.GetId() == 0)
            {
                product.SetId(++IdCounter);
            }
            var existingItem = FindStoreItemById(product.GetId());
            if (existingItem == null)
            {
                StoreItem newItem = new StoreItem(product, quantity);
                Items.Add(newItem);
                Save();
                return newItem;
            }
            else
            {
                existingItem.SetQuantity(existingItem.GetQuantity() + quantity);
                Save();
                return existingItem;
            }
        }

        public StoreItem DeleteStoreItem(int id)
        {
            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                Items.Remove(existingItem);
            }
            Save();
            return existingItem;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            return Items.FirstOrDefault(p => p.GetProduct().GetId() == id);
        }

        public List<StoreItem> GetStoreItems()
        {
            return Items;
        }

        public void Load()
        {
            FileStream stream = new(FilePath, FileMode.OpenOrCreate, FileAccess.Read);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Items = (List<StoreItem>)formatter.Deserialize(stream);
                IdCounter = Items.Count + 1;
                foreach (var item in Items)
                {
                    if (item.GetProduct().GetId() == 0)
                    {
                        item.GetProduct().SetId(++IdCounter);
                    }
                }

            }
            catch (IOException e)
            {
                throw new IOException("There has been an error opening the file to load data", e);
            }
            catch (SerializationException ex)
            {
                Items = new();
                //throw new SerializationException("There was a problem deserializing the data: " + ex.Message, ex);
            }
            finally
            {
                stream?.Dispose();
            }


        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            var existingItem = FindStoreItemById(id);
            if (existingItem != null)
            {
                if (existingItem.GetQuantity() - quantity < 0)
                {
                    existingItem.SetQuantity(0);
                }
                else
                {
                    existingItem.SetQuantity(existingItem.GetQuantity() - quantity);
                }
                Save();
                return existingItem;
            }
            else
            {
                throw new ProductDoesNotExistException();
            }
        }

        public void Save()
        {
            FileStream stream = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, Items);
            }catch (IOException e)
            {
                throw new IOException("There was a problem writing to the file", e);
            }
            catch (SerializationException ex)
            {
                throw new SerializationException("There was a problem serializing the data: " + ex.Message, ex);
            }
            finally
            {
                stream?.Dispose();
            }
        }

        private void CreatePath()
        {
            Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "Persistance");
        }
        public List<StoreItem> GetProductsByQuantity()
        {
            return new List<StoreItem>(Items.OrderByDescending(t => t.GetQuantity()));
        }

        public List<StoreItem> GetProductsByPrice()
        {
            return new List<StoreItem>(Items.OrderByDescending(t => t.GetProduct().GetPrice()));
        }

        public List<StoreItem> GetProductsByName(string name)
        {
            return new List<StoreItem>(Items.Where(i => i.GetProduct().GetName().ToLower().Contains(name.ToLower())));
        }
    }
}
