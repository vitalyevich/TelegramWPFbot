using System.Windows;
using Telegram.Bot;

namespace OPIS
{
    public partial class MainWindow : Window
    {
        TelegramBotClient bot = new TelegramBotClient(System.IO.File.ReadAllText("token.txt"));

        public MainWindow()
        {
            InitializeComponent();

            bot.OnMessage += Bot_OnMessage;

            bot.StartReceiving();

        }

        private void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                var user = new Msg()
                {
                    firstName = e.Message.Chat.FirstName,
                    msg = e.Message.Text,
                    id = e.Message.Chat.Id,
                    msgtype = e.Message.Type
                };
                listMessage.Items.Add(user);

                bot.SendTextMessageAsync(user.id, $"Тип вашего сообщения {user.msgtype}");

                if (user.msg == "Компьютер")
                {
                    bot.SendTextMessageAsync(user.id, "Компью́тер — устройство или система, способная выполнять заданную, чётко определённую, изменяемую последовательность операций. ");
                }
            });

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = (Msg)listMessage.SelectedItem;

            bot.SendTextMessageAsync(user.id, txtMsg.Text);
        }
    }
}
