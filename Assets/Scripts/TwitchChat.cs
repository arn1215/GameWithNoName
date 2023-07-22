using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class TwitchChat : MonoBehaviour
{
    [SerializeField]
    private InputField

            userField,
            passField,
            channelField;

    [SerializeField]
    private Text

            titleText,
            chatText;

    public float moveSpeed = 100.0f;

    private TcpClient twitchClient;

    private StreamReader reader;

    private StreamWriter writer;

    private bool chatConnected = false;

    // Update is called once per frame
    void Update()
    {
        ReadChat();
    }

    public void ChatConnect()
    {
        string username = userField.text;
        string password = passField.text;
        string channel = channelField.text;

        twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClient.GetStream());
        writer = new StreamWriter(twitchClient.GetStream());

        writer.WriteLine("PASS " + password);
        writer.WriteLine("NICK " + username);
        writer.WriteLine("USER " + username + " 8 * :" + username);
        writer.WriteLine("JOIN #" + channel);
        writer.Flush();
        chatConnected = true;
    }

    private void ReadChat()
    {
        if (twitchClient != null && twitchClient.Available > 0)
        {
            string message = reader.ReadLine();

            if (message.Contains("PING"))
            {
                writer.WriteLine("PONG :tmi.twitch.tv\r\n");
                writer.Flush();
                return;
            }

            if (message.Contains("PRIVMSG"))
            {
                int splitPoint = message.IndexOf("!");
                string author = message.Substring(0, splitPoint);
                author = author.Substring(1);

                splitPoint = message.IndexOf(":", 1);
                string chat = message.Substring(splitPoint + 1);

                if (chat.Contains("!death"))
                {
                    // Access the LilyHealth instance and call methods on it
                    LilyHealth lilyHealth = LilyHealth.instance;

                    // Change the current health directly
                    lilyHealth.currentHealth = 0;

                    // Damage the player (subtract 3 health points)
                    lilyHealth.DamagePlayer();
                }

                chatText.text +=
                    "<color=red>" + author + ":</color> " + chat + "\n";
            }
            else
            {
                chatText.text += message;
            }
        }
    }
}
