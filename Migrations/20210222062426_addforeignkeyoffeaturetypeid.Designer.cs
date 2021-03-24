﻿// <auto-generated />
using System;
using eCommerceWebApplication.AppData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace eCommerceWebApplication.Migrations
{
    [DbContext(typeof(ecommerceContext))]
    [Migration("20210222062426_addforeignkeyoffeaturetypeid")]
    partial class addforeignkeyoffeaturetypeid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.AppData.DBcategory", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("parent_category_id")
                        .HasColumnType("int");

                    b.Property<string>("thumbnail_image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("category_id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBfeaturetype", b =>
                {
                    b.Property<int>("featuretype_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("featuretype_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("featuretype_id");

                    b.ToTable("FeatureType");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBproduct", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<string>("prodcut_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("thumnail_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("total_quantity")
                        .HasColumnType("int");

                    b.Property<int?>("user_id")
                        .HasColumnType("int");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.HasIndex("user_id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBproductximage", b =>
                {
                    b.Property<int>("productximage_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<string>("product_images")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productximage_id");

                    b.HasIndex("product_id");

                    b.ToTable("productXimage");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBrole", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("role_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBspecificationtype", b =>
                {
                    b.Property<int>("specificationtype_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("featuretype_id")
                        .HasColumnType("int");

                    b.Property<string>("specificationtype_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("specificationtype_Id");

                    b.HasIndex("featuretype_id");

                    b.ToTable("SpecificationType");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBusers", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middlename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pincode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.HasIndex("role_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBproduct", b =>
                {
                    b.HasOne("Ecommerce.AppData.DBcategory", "DBcategory")
                        .WithMany()
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.AppData.DBusers", "DBusers")
                        .WithMany()
                        .HasForeignKey("user_id");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBproductximage", b =>
                {
                    b.HasOne("Ecommerce.AppData.DBproduct", "DBproduct")
                        .WithMany()
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.AppData.DBspecificationtype", b =>
                {
                    b.HasOne("Ecommerce.AppData.DBfeaturetype", "DBfeaturetype")
                        .WithMany()
                        .HasForeignKey("featuretype_id");
                });

            modelBuilder.Entity("Ecommerce.AppData.DBusers", b =>
                {
                    b.HasOne("Ecommerce.AppData.DBrole", "DBrole")
                        .WithMany()
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
