using AlefahERP.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlefahERP.Repository
{
    public class AlefahDbContext:DbContext
    {

        public AlefahDbContext(DbContextOptions<AlefahDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<viewUsers>().HasNoKey();
            modelBuilder.Entity<viewCustomers>().HasNoKey();
            modelBuilder.Entity<viewCustomersPET>().HasNoKey();
            modelBuilder.Entity<viewEmployees>().HasNoKey();
            modelBuilder.Entity<viewBranch>().HasNoKey();
            modelBuilder.Entity<viewServiceDetails>().HasNoKey();
            modelBuilder.Entity<viewBookingHead>().HasNoKey();
            modelBuilder.Entity<viewBookingDetails>().HasNoKey();
            modelBuilder.Entity<viewCustomerAddressLines>().HasNoKey();
            modelBuilder.Entity<_ApointmentsCounter>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<viewUsers> viewUsers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<viewCustomers> viewCustomers { get; set; }
        public DbSet<viewCustomersPET> viewCustomersPET { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<viewEmployees> viewEmployees { get; set; }
        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<BookingHead> BookingHead { get; set; }
        public DbSet<BookingStatus> BookingStatus { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CultureCodes> CultureCodes { get; set; }
        public DbSet<CustomersPET> CustomersPET { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<MembershipCategory> MembershipCategory { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<CustomersAddressLines> CustomersAddressLines { get; set; }
        public DbSet<ServiceDetails> ServiceDetails { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<viewBranch> viewBranch { get; set; }
        public DbSet<viewServiceDetails> viewServiceDetails { get; set; }
        public DbSet<viewBookingHead> viewBookingHead { get; set; }
        public DbSet<viewBookingDetails> viewBookingDetails { get; set; }
        public DbSet<BranchSchedules> BranchSchedules { get; set; }
        public DbSet<viewCustomerAddressLines> viewCustomerAddressLines { get; set; }
        public DbSet<AddressLineType> AddressLineType { get; set; }
        public DbSet<PetBloodChemistryDetails> PetBloodChemistryDetails { get; set; }
        public DbSet<PetBloodChemistryTypes> PetBloodChemistryTypes { get; set; }
        public DbSet<PetBloodScreenDetails> PetBloodScreenDetails { get; set; }
        public DbSet<PetBloodScreenTypes> PetBloodScreenTypes { get; set; }
        public DbSet<PetBreeds> PetBreeds { get; set; }
        public DbSet<PetColors> PetColors { get; set; }
        public DbSet<PetSizes> PetSizes { get; set; }
        public DbSet<PetExamineDetails> PetExamineDetails { get; set; }
        public DbSet<PetExamineTypes> PetExamineTypes { get; set; }
        public DbSet<PetOrigins> PetOrigins { get; set; }
        public DbSet<PetSpecies> PetSpecies { get; set; }
        public DbSet<PetSubSpecies> PetSubSpecies { get; set; }
        public DbSet<_ApointmentsCounter> _ApointmentsCounter { get; set; }

    }
}
