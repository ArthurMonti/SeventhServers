﻿using SeventhServers.Domain.DomainObjects;

namespace SeventhServers.Domain.Models
{
    public class Server : Entity
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }

        public DateTime? DeletedAt { get; set; }
        public virtual IEnumerable<Video> Videos { get; set; }

        public static Server New(string Name, string Ip, int Port)
        {
            return new()
            {
                Name = Name,
                Ip = Ip,
                Port = Port,
                CreatedAt = DateTime.Now,
            };
        }

        public void Update(string Name, string Ip, int Port)
        {
            this.Name = Name;
            this.Ip = Ip;
            this.Port = Port;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }


    }
}
