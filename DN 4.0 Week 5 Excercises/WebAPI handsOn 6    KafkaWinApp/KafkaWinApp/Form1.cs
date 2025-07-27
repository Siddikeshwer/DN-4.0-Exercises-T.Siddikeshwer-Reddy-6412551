using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace KafkaWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if the text box is empty
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get message text
            string payload = textBox1.Text.Trim();
            string topic = "chat-message";
            Uri uri = new Uri("http://localhost:9092"); // Kafka broker URI

            // Send message in a background thread to prevent UI freezing
            var sendMessage = new Thread(() =>
            {
                try
                {
                    var msg = new KafkaNet.Protocol.Message(payload);
                    var options = new KafkaNet.Model.KafkaOptions(uri);
                    var router = new KafkaNet.BrokerRouter(options);
                    var client = new KafkaNet.Producer(router);

                    client.SendMessageAsync(topic, new List<KafkaNet.Protocol.Message> { msg }).Wait();

                    // Update list box from UI thread
                    this.Invoke((MethodInvoker)delegate {
                        listBox1.Items.Add("Sent: " + payload);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending message: " + ex.Message);
                }
            });

            sendMessage.Start();
            textBox1.Clear();
        }
    }
}
