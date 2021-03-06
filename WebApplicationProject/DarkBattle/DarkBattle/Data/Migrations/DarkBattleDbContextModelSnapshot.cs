﻿// <auto-generated />
using DarkBattle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DarkBattle.Data.Migrations
{
    [DbContext(typeof(DarkBattleDbContext))]
    partial class DarkBattleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChampionConsumable", b =>
                {
                    b.Property<string>("ChampionConsumablesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChampionConsumablesId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChampionConsumablesId", "ChampionConsumablesId1");

                    b.HasIndex("ChampionConsumablesId1");

                    b.ToTable("ChampionConsumable");
                });

            modelBuilder.Entity("ChampionItem", b =>
                {
                    b.Property<string>("ChampionsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChampionsId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("ChampionItem");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Champion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Agility")
                        .HasColumnType("int");

                    b.Property<int>("Expirence")
                        .HasColumnType("int");

                    b.Property<int>("Expirience")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpellPower")
                        .HasColumnType("int");

                    b.Property<int>("Strenght")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Champions");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Consumable", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MerchantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestoreHealth")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MerchantId");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Creature", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Block")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("Expirience")
                        .HasColumnType("int");

                    b.Property<int>("Gold")
                        .HasColumnType("int");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Creatures");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Item", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("CreatureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<string>("MerchantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ObtainBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredLevel")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatureId");

                    b.HasIndex("MerchantId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Merchant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Merchants");
                });

            modelBuilder.Entity("ChampionConsumable", b =>
                {
                    b.HasOne("DarkBattle.Data.Models.Champion", null)
                        .WithMany()
                        .HasForeignKey("ChampionConsumablesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DarkBattle.Data.Models.Consumable", null)
                        .WithMany()
                        .HasForeignKey("ChampionConsumablesId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChampionItem", b =>
                {
                    b.HasOne("DarkBattle.Data.Models.Champion", null)
                        .WithMany()
                        .HasForeignKey("ChampionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DarkBattle.Data.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Consumable", b =>
                {
                    b.HasOne("DarkBattle.Data.Models.Merchant", null)
                        .WithMany("Consumables")
                        .HasForeignKey("MerchantId");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Item", b =>
                {
                    b.HasOne("DarkBattle.Data.Models.Creature", "Creature")
                        .WithMany("Items")
                        .HasForeignKey("CreatureId");

                    b.HasOne("DarkBattle.Data.Models.Merchant", null)
                        .WithMany("Items")
                        .HasForeignKey("MerchantId");

                    b.Navigation("Creature");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Creature", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("DarkBattle.Data.Models.Merchant", b =>
                {
                    b.Navigation("Consumables");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
