using CKK.Logic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    [Serializable]
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GetId()
        {
            return Id;
        }

        public void SetId(int id)
        {
            if (id >= 0)
            {
                Id = id;
            } else
            {
                throw new InvalidIdException();
            }

        }

        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
