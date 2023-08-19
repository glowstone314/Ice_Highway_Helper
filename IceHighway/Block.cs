﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ice_Highway_Helper.IceHighway
{
    public class Block
    {
        public static readonly Block air = new Block("minecraft:air");

        public string id;
        public Hashtable properties;
        
        // 支持带[属性]的方块
        public Block(string id)
        {
            if (id.Contains("[") && id.Contains("]"))
            {
                this.id = getId(id.Substring(0, id.IndexOf('[')));
                this.properties = new Hashtable();
                string properties = id.Substring(id.IndexOf('[') + 1, id.LastIndexOf(']'));
                properties = properties.Replace(", ", ",");
                string[] pros = properties.Split(",");
                foreach (string pro in pros)
                {
                    string[] pp = pro.Split("=");
                    if (pp.Length == 2)
                    {
                        this.properties.Add(pp[0], pp[1]);
                    }
                }
            }
            else
            {
                this.id = getId(id);
                this.properties = null;
            }
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (id == null ? 0 : id.GetHashCode());
            result = 31 * result + (properties == null ? 0 : properties.GetHashCode());
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null || GetType() != obj.GetType()) return false;
            Block block = (Block) obj;
            return id.Equals(block.id) && properties.Equals(block.properties);
        }

        // 自动加上默认前缀
        private static string getId(string id)
        {
            if (id.Contains(":"))
            {
                return id;
            }
            else
            {
                return "minecraft:" + id;
            }
        }
    }
}