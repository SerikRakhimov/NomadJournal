using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomadJournal
{
    public class Choice
    {
        private string check;
        private int i, number;

        public void DataInit()
        {

            using (DataContext context = new DataContext())
            {
                context.Journals.RemoveRange(context.Journals);
                context.Clients.RemoveRange(context.Clients);
                context.Receipts.RemoveRange(context.Receipts);
                context.SaveChanges();

                Journal journal1 = new Journal
                {
                    Dv = 24229,
                    Theme = "Журнал за 01.2019",
                    Send = false,
                    SendCompany = ""
                };
                Journal journal2 = new Journal
                {
                    Dv = 24230,
                    Theme = "Журнал за 02.2019",
                    Send = false,
                    SendCompany = ""
                };
                Journal journal3 = new Journal
                {
                    Dv = 24231,
                    Theme = "Журнал за 03.2019",
                    Send = false,
                    SendCompany = ""
                };
                Journal journal4 = new Journal
                {
                    Dv = 24232,
                    Theme = "Журнал за 04.2019",
                    Send = false,
                    SendCompany = ""
                };
                context.Journals.AddRange(new List<Journal> { journal1, journal2, journal3, journal4 });
                Client client1 = new Client
                {
                    Fio = "Иванов И.И.",
                    Email = "s1@mail.ru",
                    Period = 12,
                    StartMn = 1,
                    StartYr = 2019,
                    StartDv = 24229,
                    FinishDv = 24240,
                    Sum = 12000,
                    Work = true
                };
                Client client2 = new Client
                {
                    Fio = "Петров И.И.",
                    Email = "s2@mail.ru",
                    Period = 24,
                    StartMn = 1,
                    StartYr = 2019,
                    StartDv = 24229,
                    FinishDv = 24252,
                    Sum = 12000,
                    Work = true
                };
                Client client3 = new Client
                {
                    Fio = "Сидоров И.И.",
                    Email = "s3@mail.ru",
                    Period = 36,
                    StartMn = 1,
                    StartYr = 2019,
                    StartDv = 24229,
                    FinishDv = 24264,
                    Sum = 12000,
                    Work = true
                };

                context.Clients.AddRange(new List<Client> { client1, client2, client3 });
                context.SaveChanges();

            }
        }

        public void Subscription()
        {
            Console.WriteLine("\n\tОформление подписки.");

            Console.Write("\n\tВаша Фамилия И.О. = ");
            string fio = Console.ReadLine();

            Console.Write("\tВаш электронный почтовый адрес (также используется в качестве логина для входа) = ");
            string email = Console.ReadLine();

            while (true)
            {
                Console.Write($"\n\tВведите период подписки (12,24,36) = ");
                check = Console.ReadLine();
                if ((check == "12") || (check == "24") || (check == "36"))
                {
                    break;
                }
            }

            int period = int.Parse(check);

            Console.Write($"\n\tВведите дату начала подписки: месяц = ");
            check = Console.ReadLine();
            int startMn = int.Parse(check);
            Console.Write($"\t год = ");
            check = Console.ReadLine();
            int startYr = int.Parse(check);

            Dv start = new Dv(startMn, startYr);

            int startDv = start.DvResult();
            int finishDv = startDv + period - 1;
            int sum = period * 1000;
            bool work = true;

            using (DataContext context = new DataContext())
            {
                Client client1 = new Client
                {
                    Fio = fio,
                    Email = email,
                    Period = period,
                    StartMn = startMn,
                    StartYr = startYr,
                    StartDv = startDv,
                    FinishDv = finishDv,
                    Sum = sum,
                    Work = work
                };

                context.Clients.Add(client1);
                context.SaveChanges();
                Console.Write($"\n\tПодписка оформлена.");
                Console.Write($"\n\tСумма подписки = {sum}");

            }
        }

            public void InputClient()
            {
                Console.WriteLine("\n\tВход для клиента");

                Console.Write("\tВаш электронный почтовый адрес (также используется в качестве логина для входа) = ");
                string email = Console.ReadLine();

            using (DataContext context = new DataContext())
            {
                var clients = context.Clients.Where(client1 => client1.Email == email).ToList();
                Client client = clients.FirstOrDefault();

                if (clients.Count == 0)
                {
                    Console.WriteLine("\n\tТакой клиент не найден!");
                    return;
                }

                while (true)
                {
                    Console.WriteLine("\t1 - Отмена подписки");
                    Console.WriteLine("\t2 - Получение журналов");
                    Console.WriteLine("\t0 - Выход");
                    Console.Write($"\n\t  Ваш выбор =");
                    check = Console.ReadLine();
                    if ((check == "0") || (check == "1") || (check == "2"))
                    {
                        break;
                    }
                }
                if (check == "0")
                {
                    return;
                }
                else if (check == "1")
                {
                    while (true)
                    {
                        Console.Write($"\n\t Подтвердите отмену подписку (1-да,0-нет) =");
                        check = Console.ReadLine();
                        if ((check == "0") || (check == "1"))
                        {
                            break;
                        }
                    }
                    if (check == "1")
                    {
                        client.Work = false;
                        context.SaveChanges();
                        Console.WriteLine("\n\tПодписка отменена!");
                    }

                }

            }

        }
    }
}
