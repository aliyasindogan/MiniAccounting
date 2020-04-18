using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniAccounting.Models
{
    public class DbInitializer : CreateDatabaseIfNotExists<MiniAccountingContext>
    {
        protected override void Seed(MiniAccountingContext context)
        {
            if (!context.MeasurementUnit.Any())
            {
                MeasurementUnit measurementUnit1 = new MeasurementUnit { MeasurementUnitName = "Adet" };
                context.MeasurementUnit.Add(measurementUnit1);
                context.SaveChanges();

                MeasurementUnit measurementUnit2 = new MeasurementUnit { MeasurementUnitName = "Düzine" };
                context.MeasurementUnit.Add(measurementUnit2);
                context.SaveChanges();

                MeasurementUnit measurementUnit3 = new MeasurementUnit { MeasurementUnitName = "Gram" };
                context.MeasurementUnit.Add(measurementUnit3);
                context.SaveChanges();

                MeasurementUnit measurementUnit4 = new MeasurementUnit { MeasurementUnitName = "Kilogram" };
                context.MeasurementUnit.Add(measurementUnit4);
                context.SaveChanges();

                MeasurementUnit measurementUnit5 = new MeasurementUnit { MeasurementUnitName = "Koli" };
                context.MeasurementUnit.Add(measurementUnit5);
                context.SaveChanges();
            }
            if (!context.TaxRate.Any())
            {
                TaxRate taxRate1 = new TaxRate { TaxName = "Kdv %18", TaxRateValue = 18 };
                context.TaxRate.Add(taxRate1);
                context.SaveChanges();

                TaxRate taxRate2 = new TaxRate { TaxName = "Kdv %8", TaxRateValue = 8 };
                context.TaxRate.Add(taxRate2);
                context.SaveChanges();

                TaxRate taxRate3 = new TaxRate { TaxName = "Kdv %1", TaxRateValue = 1 };
                context.TaxRate.Add(taxRate3);
                context.SaveChanges();

                TaxRate taxRate4 = new TaxRate { TaxName = "Kdv %0", TaxRateValue = 0 };
                context.TaxRate.Add(taxRate4);
                context.SaveChanges();
            }
            if (!context.UserType.Any())
            {
                UserType userType1 = new UserType { UserTypeName = "System Admin" };
                context.UserType.Add(userType1);
                context.SaveChanges();

                UserType userType2 = new UserType { UserTypeName = "Admin" };
                context.UserType.Add(userType2);
                context.SaveChanges();
            }
            if (!context.User.Any())
            {
                User user1 = new User { UserName = "aliyasin", FirstName = "Ali Yasin", LastName = "Doğan", Email = "a.yasindogan@gmail.com", Password = "12345", UserTypeID = 1 };
                context.User.Add(user1);
                context.SaveChanges();
            }
            base.Seed(context);
        }
    }
}