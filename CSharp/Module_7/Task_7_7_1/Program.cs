namespace Task_7_7_1
{
      internal class Program
      {
            abstract class Delivery
            {
                private string address;

                public string Address
                {
                    get { return address; }
                    set
                    {
                        if (value != null)
                        {
                            address = value;
                        }
                    }
                }

                public Delivery(string address)
                {
                    this.address = address;
                }
                protected virtual void Deliver(string address)
                {
                    Console.WriteLine("Не определен тип-доставки по адресу {0}", address);
                }
            }
            class HomeDelivery : Delivery
            {
                protected string Courier;
                public HomeDelivery(string address, string courier) : base(address)
                {
                    Courier = courier;
                }

                protected override void Deliver(string address)
                {
                    Console.WriteLine("{0} доставит поссылку надом по адресу {1}", Courier, address);
                }

            }
            class PickPointDelivery : Delivery
            {
                protected string NamePickPoint;
                public PickPointDelivery(string address, string namePickPoint) : base(address)
                {
                    NamePickPoint = namePickPoint;
                }

                protected override void Deliver(string address)
                {
                    Console.WriteLine("Доставка в {0} по адресу {1}", NamePickPoint, address);
                }
            }
            class ShopDelivery : Delivery
            {
                protected string NameShop;
                public ShopDelivery(string address, string nameShop) : base(address)
                {
                    NameShop = nameShop;
                }

                protected override void Deliver(string address)
                {
                    Console.WriteLine("Доставка в {0} по адресу {1}", NameShop, address);
                }
            }
            class Order<TDelivery>
                     where TDelivery : Delivery

            {
                public TDelivery Delivery;
                public ProductList Products;

                public int Id;

                public string Description;

                public Order(TDelivery delivery, ProductList products, int id, string description)
                {
                    Delivery = delivery;
                    Products = products;
                    Id = id;
                    Description = description;

                }

                public void DisplayAddress()
                {
                    Console.WriteLine(Delivery.Address);
                }


            }
            class Product
            {
                public string Name;
                public string Description;
                public double Price;
                //public Product(string name, string description, double price)
                //{
                //    Name = name;
                //    Description = description;
                //    Price = price;
                //}
            }
            class ProductList
            {
                public Product[] list;
                public ProductList(Product[] list)
                {
                    this.list = list;
                }

                public Product this[int index]
                {
                    get
                    {
                        if (index >= 0 && index < list.Length)
                        {
                            return list[index];
                        }
                        else
                        {
                            return null;
                        }
                    }
                    private set
                    {
                        if (index >= 0 && index < list.Length)
                        {
                            list[index] = value;
                        }
                    }
                }

                public Product this[string name]
                {
                    get
                    {
                        for (int i = 0; i < list.Length; i++)
                        {
                            if (list[i].Name == name)
                            {
                                return list[i];
                            }
                        }
                        return null;
                    }
                }

            }

            static void Main(string[] args)
            {
                var pickPointDelivery = new PickPointDelivery("ул.Фестивальная 13", "Пятерочка");

                var products = new Product[]
                {
                new Product{ Name = "Noodles", Description = "too Hot", Price = 500 },
                new Product{ Name = "Gif", Description = "so cute", Price = 10000 },
                };
                var productsList = new ProductList(products);

                var order1 = new Order<PickPointDelivery>(pickPointDelivery, productsList, 4143241, "Доставка некоторого кол-ва товаров");

                var product1 = productsList["Noodles"].Name;
                var price1 = productsList["Noodles"].Price;

                Console.WriteLine($"{product1} обойдется вам в {price1} руб.");

                Console.WriteLine("Заказ отправлен по адресу :");

                order1.DisplayAddress();

            }
      }
    

}