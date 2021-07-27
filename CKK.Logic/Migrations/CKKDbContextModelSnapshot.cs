﻿// <auto-generated />
using CKK.Logic.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CKK.Logic.Migrations
{
    [DbContext(typeof(CKKDbContext))]
    partial class CKKDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CKK.Logic.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CKK.Logic.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CKK.Logic.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("CKK.Logic.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("CKK.Logic.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("ShoppingCartShoppingCartItem", b =>
                {
                    b.Property<int>("CartsShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("ShoppingCartItemsShoppingCartItemId")
                        .HasColumnType("int");

                    b.HasKey("CartsShoppingCartId", "ShoppingCartItemsShoppingCartItemId");

                    b.HasIndex("ShoppingCartItemsShoppingCartItemId");

                    b.ToTable("ShoppingCartShoppingCartItem");
                });

            modelBuilder.Entity("CKK.Logic.Models.Customer", b =>
                {
                    b.HasOne("CKK.Logic.Models.ShoppingCart", "Cart")
                        .WithOne("Customer")
                        .HasForeignKey("CKK.Logic.Models.Customer", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("CKK.Logic.Models.Order", b =>
                {
                    b.HasOne("CKK.Logic.Models.ShoppingCart", "ShoppingCart")
                        .WithMany()
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("CKK.Logic.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("CKK.Logic.Models.Product", "Product")
                        .WithMany("Items")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShoppingCartShoppingCartItem", b =>
                {
                    b.HasOne("CKK.Logic.Models.ShoppingCart", null)
                        .WithMany()
                        .HasForeignKey("CartsShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CKK.Logic.Models.ShoppingCartItem", null)
                        .WithMany()
                        .HasForeignKey("ShoppingCartItemsShoppingCartItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CKK.Logic.Models.Product", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CKK.Logic.Models.ShoppingCart", b =>
                {
                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}
