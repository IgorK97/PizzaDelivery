using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public partial class PizzaDeliveryContext : DbContext
{
    public PizzaDeliveryContext()
    {
    }

    public PizzaDeliveryContext(DbContextOptions<PizzaDeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Courier> Couriers { get; set; }

    public virtual DbSet<DelStatus> DelStatuses { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<Pizza> Pizzas { get; set; }

    public virtual DbSet<PizzaSize> PizzaSizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=PizzaDelivery;Username=postgres;Password=My2000Name");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey1");

            entity.ToTable("clients");

            entity.HasIndex(e => e.Login, "clients_login_key1").IsUnique();

            entity.HasIndex(e => e.Phone, "clients_phone_key1").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('users_id_seq1'::regclass)");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Courier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("couriers_pkey1");

            entity.ToTable("couriers");

            entity.HasIndex(e => e.Login, "couriers_login_key1").IsUnique();

            entity.HasIndex(e => e.Phone, "couriers_phone_key1").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('users_id_seq1'::regclass)");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<DelStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DelStatus_pkey");

            entity.ToTable("DelStatus");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredients_pkey");

            entity.ToTable("ingredients");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Big)
                .HasPrecision(10, 2)
                .HasColumnName("big");
            entity.Property(e => e.Ingrimage).HasColumnName("ingrimage");
            entity.Property(e => e.Medium)
                .HasPrecision(10, 2)
                .HasColumnName("medium");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("_name");
            entity.Property(e => e.PricePerGram)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_gram");
            entity.Property(e => e.Small)
                .HasPrecision(10, 2)
                .HasColumnName("small");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("managers_pkey1");

            entity.ToTable("managers");

            entity.HasIndex(e => e.Login, "managers_login_key1").IsUnique();

            entity.HasIndex(e => e.Phone, "managers_phone_key1").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('users_id_seq1'::regclass)");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.AddressDel)
                .HasMaxLength(255)
                .HasColumnName("address_del");
            entity.Property(e => e.ClientId).HasColumnName("clientId");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.CourierId).HasColumnName("courierId");
            entity.Property(e => e.Deliverytime).HasColumnName("deliverytime");
            entity.Property(e => e.DelstatusId).HasColumnName("delstatusId");
            entity.Property(e => e.FinalPrice)
                .HasPrecision(10, 2)
                .HasColumnName("final_price");
            entity.Property(e => e.ManagersId).HasColumnName("managersId");
            entity.Property(e => e.Ordertime).HasColumnName("ordertime");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_clientId_fkey");

            entity.HasOne(d => d.Courier).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CourierId)
                .HasConstraintName("orders_courierId_fkey");

            entity.HasOne(d => d.Delstatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DelstatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_delstatus_id_fkey");

            entity.HasOne(d => d.Managers).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ManagersId)
                .HasConstraintName("orders_managersId_fkey");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pizza_orders_pkey");

            entity.ToTable("order_lines");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Custom)
                .HasDefaultValue(false)
                .HasColumnName("custom");
            entity.Property(e => e.OrdersId).HasColumnName("ordersId");
            entity.Property(e => e.PizzaId).HasColumnName("pizzaId");
            entity.Property(e => e.PizzaSizesId).HasColumnName("pizza_sizesId");
            entity.Property(e => e.PositionPrice)
                .HasPrecision(10, 2)
                .HasColumnName("position_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("pizza_orders_order_Id_fkey");

            entity.HasOne(d => d.Pizza).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.PizzaId)
                .HasConstraintName("pizza_orders_pizza_id_fkey");

            entity.HasOne(d => d.PizzaSizes).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.PizzaSizesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pizza_sizes_id_fkey");

            entity.HasMany(d => d.Ingredients).WithMany(p => p.OrderLines)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomIngredient",
                    r => r.HasOne<Ingredient>().WithMany()
                        .HasForeignKey("IngredientsId")
                        .HasConstraintName("ingredients_id_fkey"),
                    l => l.HasOne<OrderLine>().WithMany()
                        .HasForeignKey("OrderLinesId")
                        .HasConstraintName("order_lines_id_fkey"),
                    j =>
                    {
                        j.HasKey("OrderLinesId", "IngredientsId").HasName("custom_ingredients_pkey");
                        j.ToTable("custom_ingredients");
                        j.IndexerProperty<int>("OrderLinesId").HasColumnName("order_linesId");
                        j.IndexerProperty<int>("IngredientsId").HasColumnName("ingredientsId");
                    });
        });

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pizza_pkey");

            entity.ToTable("pizza");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("_name");
            entity.Property(e => e.Pizzaimage).HasColumnName("pizzaimage");

            entity.HasMany(d => d.Ingredients).WithMany(p => p.Pizzas)
                .UsingEntity<Dictionary<string, object>>(
                    "PizzaComposition",
                    r => r.HasOne<Ingredient>().WithMany()
                        .HasForeignKey("IngredientsId")
                        .HasConstraintName("pizza_composition_ingredients_id_fkey"),
                    l => l.HasOne<Pizza>().WithMany()
                        .HasForeignKey("PizzaId")
                        .HasConstraintName("pizza_composition_pizza_id_fkey"),
                    j =>
                    {
                        j.HasKey("PizzaId", "IngredientsId").HasName("pizza_composition_pkey");
                        j.ToTable("pizza_composition");
                        j.IndexerProperty<int>("PizzaId").HasColumnName("pizzaId");
                        j.IndexerProperty<int>("IngredientsId").HasColumnName("ingredientsId");
                    });
        });

        modelBuilder.Entity<PizzaSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pizza_sizes_pkey");

            entity.ToTable("pizza_sizes");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey1");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key1").IsUnique();

            entity.HasIndex(e => e.Login, "users_login_key1").IsUnique();

            entity.HasIndex(e => e.Phone, "users_phone_key1").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("nextval('users_id_seq1'::regclass)");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
