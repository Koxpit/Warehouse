using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.Database
{
    public static class FirstData
    {
        public static void Initialize(WarehouseContext context)
        {
            InitWorkers(context);
            InitVehicle(context);
            InitPassports(context);
            InitStorage(context);
            InitProducts(context);
            InitCargos(context);
            InitCustomers(context);
            InitOrders(context);
            InitPlaces(context);
        }

        private static void InitWorkers(WarehouseContext context)
        {
            if (!context.Workers.Any())
            {
                context.Workers.AddRange(
                    new Worker
                    {
                        FIO = "Молодов Геннадий Викторович",
                        Birthday = Convert.ToDateTime("22.07.1998"),
                        PhoneNumber = "89953468162",
                        Number = "00001",
                        Position = "Грузчик",
                        Experience = 1
                    },
                    new Worker
                    {
                        FIO = "Чекарев Михаил Александрович",
                        Birthday = Convert.ToDateTime("11.05.1989"),
                        PhoneNumber = "89953468500",
                        Number = "00002",
                        Position = "Грузчик",
                        Experience = 2
                    },
                    new Worker
                    {
                        FIO = "Музов Кирилл Викторович",
                        Birthday = Convert.ToDateTime("25.02.1986"),
                        PhoneNumber = "89953468345",
                        Number = "10001",
                        Position = "Погрузчик",
                        Experience = 3
                    },
                    new Worker
                    {
                        FIO = "Лесов Павел Кириллович",
                        Birthday = Convert.ToDateTime("10.09.1987"),
                        PhoneNumber = "89953468999",
                        Number = "10002",
                        Position = "Погрузчик",
                        Experience = 2
                    },
                    new Worker
                    {
                        FIO = "Трубнов Владимир Петрович",
                        Birthday = Convert.ToDateTime("21.10.1995"),
                        PhoneNumber = "89953468533",
                        Number = "20001",
                        Position = "Кладовщик",
                        Experience = 1
                    },
                    new Worker
                    {
                        FIO = "Рощена Мария Павловна",
                        Birthday = Convert.ToDateTime("20.01.1972"),
                        PhoneNumber = "89953468532",
                        Number = "20002",
                        Position = "Старший кладовщик",
                        Experience = 5
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitVehicle(WarehouseContext context)
        {
            if (!context.Vehicles.Any())
            {
                context.Drivers.AddRange(
                    new Driver
                    {
                        FIO = "Самсонов Владимир Геннадьевич",
                        Birthday = Convert.ToDateTime("02.06.1982"),
                        PhoneNumber = "89155326672",
                        Experience = 5
                    },
                    new Driver
                    {
                        FIO = "Вишняков Рудольф Мартынович",
                        Birthday = Convert.ToDateTime("11.10.1975"),
                        PhoneNumber = "89155326102",
                        Experience = 10
                    },
                    new Driver
                    {
                        FIO = "Симонов Корнелий Якунович",
                        Birthday = Convert.ToDateTime("22.11.1979"),
                        PhoneNumber = "89155326188",
                        Experience = 9
                    },
                    new Driver
                    {
                        FIO = "Шарапов Иннокентий Федосеевич",
                        Birthday = Convert.ToDateTime("23.04.1999"),
                        PhoneNumber = "89155326001",
                        Experience = 3
                    }
                );

                context.SaveChanges();

                context.Vehicles.AddRange(
                    new Vehicle
                    {
                        Name = "МАЗ-5440М9",
                        Number = "A999AA",
                        Capacity = 32,
                        DriverId = 1
                    },
                    new Vehicle
                    {
                        Name = "Foton Auman H5",
                        Number = "Y645TO",
                        Capacity = 36,
                        DriverId = 2
                    },
                    new Vehicle
                    {
                        Name = "MAN TGS",
                        Number = "X112BX",
                        Capacity = 22,
                        DriverId = 3
                    },
                    new Vehicle
                    {
                        Name = "Hyundai Mighty",
                        Number = "X235YM",
                        Capacity = 33,
                        DriverId = 4
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitPassports(WarehouseContext context)
        {
            if (!context.Passports.Any())
            {
                context.Passports.AddRange(
                    new Passport
                    {
                        Series = "4415",
                        Number = "900320",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("01.02.2010"),
                        PersonId = 1
                    },
                    new Passport
                    {
                        Series = "4542",
                        Number = "900321",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("04.03.2011"),
                        PersonId = 2
                    },
                    new Passport
                    {
                        Series = "4418",
                        Number = "900324",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("20.01.2012"),
                        PersonId = 3
                    },
                    new Passport
                    {
                        Series = "4417",
                        Number = "900329",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("17.08.2016"),
                        PersonId = 4
                    },
                    new Passport
                    {
                        Series = "4420",
                        Number = "900327",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("12.04.2009"),
                        PersonId = 5
                    },
                    new Passport
                    {
                        Series = "4440",
                        Number = "900330",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("11.06.2018"),
                        PersonId = 6
                    },
                    new Passport
                    {
                        Series = "4441",
                        Number = "901001",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("19.01.2012"),
                        PersonId = 7
                    },
                    new Passport
                    {
                        Series = "4499",
                        Number = "901310",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("13.08.2016"),
                        PersonId = 8
                    },
                    new Passport
                    {
                        Series = "4456",
                        Number = "901326",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("18.04.2009"),
                        PersonId = 9
                    },
                    new Passport
                    {
                        Series = "4378",
                        Number = "901456",
                        IssuedAt = "МСК МУНИЦ МО РФ",
                        IssuedWas = Convert.ToDateTime("17.06.2018"),
                        PersonId = 10
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitStorage(WarehouseContext context)
        {
            if (!context.Storages.Any())
            {
                context.Storages.AddRange(
                    new Storage
                    {
                        Name = "Модуль-5",
                        Territory = "ЗЯБ",
                        City = "Ступино"
                    },
                    new Storage
                    {
                        Name = "СЗЯБ",
                        Territory = "ЗЯБ",
                        City = "Ступино"
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitProducts(WarehouseContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Хрустим Багет Томат и Зелень 60г 24X",
                        Code = "00001006743",
                        Party = "S000000001",
                        DateOfManufacture = Convert.ToDateTime("11.03.2021"),
                        Term = Convert.ToDateTime("28.07.21"),
                        CodeOfPallete = "KA00000001",
                        BoxesInPallete = 64,
                        Cost = 8000
                    },
                    new Product
                    {
                        Name = "Лейз Из Печи Королевский Краб 85г 12X",
                        Code = "00002007826",
                        Party = "S000000001",
                        DateOfManufacture = Convert.ToDateTime("11.03.2021"),
                        Term = Convert.ToDateTime("28.07.21"),
                        CodeOfPallete = "KA00000002",
                        BoxesInPallete = 144,
                        Cost = 12000
                    },
                    new Product
                    {
                        Name = "Лейз Стакс Зеленый Лук 140г 9X",
                        Code = "000010015976",
                        Party = "S000000002",
                        DateOfManufacture = Convert.ToDateTime("20.02.2021"),
                        Term = Convert.ToDateTime("20.02.2022"),
                        CodeOfPallete = "KA00000003",
                        BoxesInPallete = 200,
                        Cost = 32000
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitCargos(WarehouseContext context)
        {
            if (!context.Cargos.Any())
            {
                context.Cargos.AddRange(
                    new Cargo
                    {
                        Number = "00000001",
                        NumOfPalletes = 11,
                        ProductId = 1
                    },
                    new Cargo
                    {
                        Number = "00000001",
                        NumOfPalletes = 11,
                        ProductId = 2
                    },
                    new Cargo
                    {
                        Number = "00000002",
                        NumOfPalletes = 22,
                        ProductId = 3
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitCustomers(WarehouseContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        FIO = "Корнилов Ефим Михаилович",
                        CompanyName = "Фрито Лей",
                        City = "Москва",
                        PhoneNumber = "89225120091"
                    },
                    new Customer
                    {
                        FIO = "Пономарёв Эльдар Митрофанович",
                        CompanyName = "Бамба",
                        City = "Рязань",
                        PhoneNumber = "89164427689"
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitOrders(WarehouseContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        Type = "Погрузка",
                        ArrivalTime = Convert.ToDateTime("15.04.2021"),
                        CustomerId = 1,
                        Customer = context.Customers.Find(1),
                        Cargos = new List<Cargo> { context.Cargos.Find(1), context.Cargos.Find(2) }
                    },
                    new Order
                    {
                        Type = "Выгрузка",
                        ArrivalTime = Convert.ToDateTime("17.03.2021"),
                        CustomerId = 2,
                        Customer = context.Customers.Find(2),
                        Cargos = new List<Cargo> { context.Cargos.Find(3) }
                    }
                );

                context.SaveChanges();
            }
        }
        private static void InitPlaces(WarehouseContext context)
        {
            if (!context.Places.Any())
            {
                context.Places.AddRange(
                    new Place
                    {
                        Sector = "1",
                        Number = "001",
                        StorageId = 1,
                        ProductId = 1,
                        NumOfPalletes = 11
                    },
                    new Place
                    {
                        Sector = "1",
                        Number = "002",
                        StorageId = 1,
                        ProductId = 2,
                        NumOfPalletes = 11
                    },
                    new Place
                    {
                        Sector = "1",
                        Number = "001",
                        StorageId = 1,
                        ProductId = 3,
                        NumOfPalletes = 11
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
