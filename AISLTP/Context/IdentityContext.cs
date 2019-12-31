using AISLTP.Entities;
using System;
using System.Data.Entity;

namespace AISLTP.Context
{
    public class ApplicationDbContext : DbContext
    {
        static ApplicationDbContext()
        {
            Database.SetInitializer<ApplicationDbContext>(new MyContextInitializer());
        }

        public ApplicationDbContext() : base("DefaultConnection")
        { }

        public DbSet<Sotr> Sotrs { get; set; }
        public DbSet<Lico> Licos { get; set; }
        public DbSet<Pol> Pols { get; set; }
        public DbSet<Nac> Nacs { get; set; }
        public DbSet<Obl> Obls { get; set; }
        public DbSet<Rn> Rns { get; set; }
        public DbSet<Np> Nps { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LTP> LTPs { get; set; }
        public DbSet<Medcom> Medcoms { get; set; }
        public DbSet<Osnnap> Osnnaps { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Educ> Educs { get; set; }
        public DbSet<Prof> Profs { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Vidsv> Vidsvs { get; set; }
        public DbSet<Viddebt> Viddebts { get; set; }
        public DbSet<Otnosh> Otnoshs { get; set; }
        public DbSet<Osnsocr> Osnsocrs { get; set; }
        public DbSet<Osnprod> Osnprods { get; set; }
        public DbSet<Osndosr> Osndosrs { get; set; }
        public DbSet<Samovol> Samovols { get; set; }
        public DbSet<UK> UKs { get; set; }
        public DbSet<Koap> Koaps { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Privent> Privents { get; set; }
        public DbSet<Naprav> Napravs { get; set; }
        public DbSet<Objal> Objals { get; set; }
        public DbSet<Otrad> Otrads { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<Svaz> Svazs { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkLTP> WorkLTPs { get; set; }
        public DbSet<Lechen> Lechens { get; set; }
        public DbSet<Zavis> Zaviss { get; set; }
        public DbSet<Obchest> Obchests { get; set; }
        public DbSet<Soderotnosh> Soderotnoshes { get; set; }
        public DbSet<Psix> Psixes { get; set; }
        public DbSet<Discip> Discips { get; set; }
        public DbSet<Samohod> Samohods { get; set; }
        public DbSet<Osv> Osvs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasMany(c => c.Licos)
                .WithMany(s => s.Addresses)
                .Map(t => t.MapLeftKey("AddressID")
                .MapRightKey("LicoID")
                .ToTable("Address_Lico"));

            modelBuilder.Entity<Prof>().HasMany(c => c.Licos)
                .WithMany(s => s.Profs)
                .Map(t => t.MapLeftKey("ProfId")
                .MapRightKey("LicoId")
                .ToTable("ProfLico"));

            modelBuilder.Entity<Lico>().Property(p => p.Foto)
                .HasColumnType("image");
        }
    }
    class MyContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        // Инициализация данных по-умолчанию
        protected override void Seed(ApplicationDbContext context)
        {
            // Роли
            context.Roles.Add(new Role() { ID = 1, Name = "Администратор", Code = "admin" });
            context.Roles.Add(new Role() { ID = 2, Name = "Сотрудник", Code = "simple" });
            // Администратор
            context.Users.Add(new User() { Login = "sa", Password = "1", RoleID = 1 });
            // Пол
            context.Pols.Add(new Pol() { Txt = "Мужской" });
            context.Pols.Add(new Pol() { Txt = "Женский" });
            // ЛТП
            context.LTPs.Add(new LTP()
            {
                Nom = "ЛТП №6",
                Np = "Дзержинск",
                Ul = "пер. Сервеный",
                Dom = "1",
                Pindex = 222720,
                Teldej = "8(01716)40-8-45",
                Email = "dpltp6@mail.ru"
            });
            context.LTPs.Add(new LTP()
            {
                Nom = "ЛТП №9",
                Np = "Витебск",
                Ul = "ул. Гагарина",
                Dom = "48",
                Pindex = 210026,
                Teldej = "8(0212)54-89-60",
                Email = "dpltp9@mail.ru"
            });
            // Сохранить изменения
            context.SaveChanges();
        }
    }
}