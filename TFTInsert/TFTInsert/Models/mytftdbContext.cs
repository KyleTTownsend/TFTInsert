using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
namespace TFTInsert.Models
{
    public partial class mytftdbContext : DbContext
    {
        public mytftdbContext()
        {
        }

        public mytftdbContext(DbContextOptions<mytftdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ability> Ability { get; set; }
        public virtual DbSet<AbilityStat> AbilityStat { get; set; }
        public virtual DbSet<Champion> Champion { get; set; }
        public virtual DbSet<ChampionStat> ChampionStat { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<ClassBonus> ClassBonus { get; set; }
        public virtual DbSet<ClassBonusLink> ClassBonusLink { get; set; }
        public virtual DbSet<Img> Img { get; set; }
        public virtual DbSet<ItemComponent> ItemComponent { get; set; }
        public virtual DbSet<ItemComponentStat> ItemComponentStat { get; set; }
        public virtual DbSet<ItemFull> ItemFull { get; set; }
        public virtual DbSet<ItemLink> ItemLink { get; set; }
        public virtual DbSet<Origin> Origin { get; set; }
        public virtual DbSet<OriginBonus> OriginBonus { get; set; }
        public virtual DbSet<OriginBonusLink> OriginBonusLink { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>(entity =>
            {
                entity.ToTable("ability");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.AbilityDesc)
                    .HasColumnName("ability_desc")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AbilityType)
                    .HasColumnName("ability_type")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ChampionId).HasColumnName("champion_id");

                entity.Property(e => e.ManaCost).HasColumnName("mana_cost");

                entity.Property(e => e.ManaStart).HasColumnName("mana_start");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Champion)
                    .WithMany(p => p.Ability)
                    .HasForeignKey(d => d.ChampionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ability__champio__534D60F1");
            });

            modelBuilder.Entity<AbilityStat>(entity =>
            {
                entity.ToTable("ability_stat");

                entity.Property(e => e.AbilityStatId).HasColumnName("ability_stat_id");

                entity.Property(e => e.AbilityId).HasColumnName("ability_id");

                entity.Property(e => e.StatType)
                    .HasColumnName("stat_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatValue)
                    .HasColumnName("stat_value")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.AbilityStat)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ability_s__abili__5629CD9C");
            });

            modelBuilder.Entity<Champion>(entity =>
            {
                entity.ToTable("champion");

                entity.Property(e => e.ChampionId).HasColumnName("champion_id");

                entity.Property(e => e.ChampionStatsId).HasColumnName("champion_stats_id");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OriginId).HasColumnName("origin_id");
            });

            modelBuilder.Entity<ChampionStat>(entity =>
            {
                entity.HasKey(e => e.StatId);

                entity.ToTable("champion_stat");

                entity.Property(e => e.StatId).HasColumnName("stat_id");

                entity.Property(e => e.Armor).HasColumnName("armor");

                entity.Property(e => e.AttackSpeed).HasColumnName("attack_speed");

                entity.Property(e => e.ChampionId).HasColumnName("champion_id");

                entity.Property(e => e.Damage).HasColumnName("damage");

                entity.Property(e => e.Dps).HasColumnName("dps");

                entity.Property(e => e.Health).HasColumnName("health");

                entity.Property(e => e.MagicResist).HasColumnName("magic_resist");

                entity.Property(e => e.Range).HasColumnName("range");

                entity.HasOne(d => d.Champion)
                    .WithMany(p => p.ChampionStat)
                    .HasForeignKey(d => d.ChampionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__champion___magic__59063A47");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassDesc)
                    .HasColumnName("class_desc")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImgId).HasColumnName("img_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassBonus>(entity =>
            {
                entity.ToTable("class_bonus");

                entity.Property(e => e.ClassBonusId).HasColumnName("class_bonus_id");

                entity.Property(e => e.Effect)
                    .HasColumnName("effect")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Needed)
                    .HasColumnName("needed")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassBonusLink>(entity =>
            {
                entity.HasKey(e => new { e.ClassId, e.ClassBonusId });

                entity.ToTable("class_bonus_link");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassBonusId).HasColumnName("class_bonus_id");

                entity.HasOne(d => d.ClassBonus)
                    .WithMany(p => p.ClassBonusLink)
                    .HasForeignKey(d => d.ClassBonusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__class_bon__class__74AE54BC");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassBonusLink)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__class_bon__class__73BA3083");
            });

            modelBuilder.Entity<Img>(entity =>
            {
                entity.ToTable("img");

                entity.Property(e => e.ImgId).HasColumnName("img_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemComponent>(entity =>
            {
                entity.ToTable("item_component");

                entity.Property(e => e.ItemComponentId).HasColumnName("item_component_id");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tier).HasColumnName("tier");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemComponentStat>(entity =>
            {
                entity.ToTable("item_component_stat");

                entity.Property(e => e.ItemComponentStatId).HasColumnName("item_component_stat_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ItemComponentId).HasColumnName("item_component_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ItemComponent)
                    .WithMany(p => p.ItemComponentStat)
                    .HasForeignKey(d => d.ItemComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_component_id");
            });

            modelBuilder.Entity<ItemFull>(entity =>
            {
                entity.ToTable("item_full");

                entity.Property(e => e.ItemFullId).HasColumnName("item_full_id");

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Depth).HasColumnName("depth");

                entity.Property(e => e.Kind)
                    .HasColumnName("kind")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tier).HasColumnName("tier");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemLink>(entity =>
            {
                entity.HasKey(e => new { e.ItemFullId, e.ItemComponentId });

                entity.ToTable("item_link");

                entity.Property(e => e.ItemFullId).HasColumnName("item_full_id");

                entity.Property(e => e.ItemComponentId).HasColumnName("item_component_id");

                entity.HasOne(d => d.ItemComponent)
                    .WithMany(p => p.ItemLink)
                    .HasForeignKey(d => d.ItemComponentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_component_item");

                entity.HasOne(d => d.ItemFull)
                    .WithMany(p => p.ItemLink)
                    .HasForeignKey(d => d.ItemFullId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_full_item");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("origin");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImgId).HasColumnName("img_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OriginBonus>(entity =>
            {
                entity.ToTable("origin_bonus");

                entity.Property(e => e.OriginBonusId).HasColumnName("origin_bonus_id");

                entity.Property(e => e.Effect)
                    .HasColumnName("effect")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Needed).HasColumnName("needed");
            });

            modelBuilder.Entity<OriginBonusLink>(entity =>
            {
                entity.HasKey(e => new { e.OriginId, e.OriginBonusId });

                entity.ToTable("origin_bonus_link");

                entity.Property(e => e.OriginId).HasColumnName("origin_id");

                entity.Property(e => e.OriginBonusId).HasColumnName("origin_bonus_id");

                entity.HasOne(d => d.OriginBonus)
                    .WithMany(p => p.OriginBonusLink)
                    .HasForeignKey(d => d.OriginBonusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_origin_bonus_id");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.OriginBonusLink)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_origin_id");
            });
        }
    }
}
