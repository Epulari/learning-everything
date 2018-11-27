using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//xml linq
using System.Xml.Linq;
//xml file
using System.IO;

namespace CsharpFunction
{
    /*
     * 功能
     * linq方法操作xml文件：创建xml文件 读取xml文件 查找节点或属性 增加节点或属性 删除节点或属性 修改节点或属性 替换节点或属性 移动或复制节点到当前文件 复制节点到其他xml文件
     * Epulari T 
     * 2018.4.3
     */

    /*
     * <?xml version="1.0" encoding="utf-8"?>
     * <school name="new school">
     *   <class number="01">
     *     <student id="01" name="Dan" age="18" />
     *     <student id="02" name="Tom" age="18" />
     *   </class>
     * </school>
    */
    class XmlLinq
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void CreateXml(string xmlfile)
        {
            if (!File.Exists(xmlfile))
            {

                //方法一 按照DOM方式添加
                //实例化XDocument对象 
                XDocument xdoc = new XDocument();
                //创建根节点
                XElement root = new XElement("school");
                //创建一级子节点
                XElement fchild = new XElement("class");
                fchild.SetAttributeValue("number", "01");
                //创建二级第一个子节点
                XElement schild1 = new XElement("student");
                schild1.SetAttributeValue("id", "01");
                schild1.SetAttributeValue("name", "Dan");
                schild1.SetAttributeValue("age", "18");
                //创建二级第二个子节点
                XElement schild2 = new XElement("student");
                schild2.SetAttributeValue("id", "02");
                schild2.SetAttributeValue("name", "Tom");
                schild2.SetAttributeValue("age", "18");
                //添加节点到父节点，添加根节点到对象
                fchild.Add(schild1);
                fchild.Add(schild2);
                root.Add(fchild);
                xdoc.Add(root);

                //使用XML的保存会自动在xml文件开始添加：<?xml version="1.0" encoding="utf-8"?>
                xdoc.Save("school.xml");

                //方法二 按照xml文件树状格式添加
                XDocument xd = new XDocument(
                    new XElement("school", new XAttribute("name", "new school"),
                        new XElement("class", new XAttribute("number", "01"),
                            new XElement("student", new XAttribute("id", "01"), new XAttribute("name", "Dan"), new XAttribute("age", "18")),
                            new XElement("student", new XAttribute("id", "02"), new XAttribute("name", "Tom"), new XAttribute("age", "18"))
                        )
                    )
                );
                //使用XML的保存会自动在xml文件开始添加：<?xml version="1.0" encoding="utf-8"?>
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void ReadXml(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                //省略了判定xml文件存在
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);
                XElement root = xd.Root;
                //获取根节点下所有子节点
                IEnumerable<XElement> xe = root.Elements();
                foreach (XElement fxe in xe)
                {
                    foreach (XElement sxe in fxe.Elements())
                    {
                        Console.WriteLine(sxe.Name);
                        Console.WriteLine(sxe.Attribute("id").Value);
                    }
                }
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 在文件中查找
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void SearchInXml(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);

                //获取所有节点
                IEnumerable<XNode> nodes = xd.DescendantNodes();
                //找到单个节点
                IEnumerable<XElement> node = xd.Descendants("class");
                //找到特点节点 子节点有element且其属性id值为01
                IEnumerable<XElement> element = xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01");
                //如果只取一个，可以用下面这个方法 First表示枚举中的第一个
                XElement element_first = xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First();

                //把结果保存到单独的xml文件以进行观察
                XDocument xd_nodes = new XDocument(
                    new XElement("school",
                       nodes
                     )
                );
                xd_nodes.Save("nodes.xml");

                XDocument xd_node = new XDocument(
                    new XElement("school",
                       node
                     )
                );
                xd_node.Save("node.xml");

                XDocument xd_element = new XDocument(
                    new XElement("school",
                       element
                     )
                );
                xd_element.Save("element.xml");


                //获取值
                var selement = xd.Descendants("class")
                    .Select(p => new { age = p.Element("student") }); //获得节点

                var welement = xd.Descendants("class")
                    .Where(p => p.Element("student").Attribute("name").Value.Contains("D"))  //条件筛选 寻找student：其name属性的值包含有字母D
                    .Select(p => new { age = p.Element("student") }); //获得节点

                //输出结果
                string strs = "";
                foreach (var a in selement)
                {
                    strs += a.age + "\r\n";
                }

                Console.Write(strs);

                string strw = "";
                foreach (var a in selement)
                {
                    strw += a.age + "\r\n";
                }

                Console.Write(strw);

                Console.Read();
            }
        }

        /// <summary>
        /// 追加节点、属性和内容
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void AppendNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);

                XElement parent_class = xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First();
                XElement ele = new XElement("student", new XAttribute("id", "03"), "Sue");
                parent_class.Add(ele);
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void DeleteNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);

                //删除节点 全部没有了
                xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First()
                    .Remove();
                //删除节点内容 只剩下节点名
                xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First()
                    .RemoveAll();
                //删除节点属性 内容还在
                xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First()
                    .RemoveAttributes();
                //删除节点内容 只剩下节点名和属性
                xd.Descendants("class")
                    .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First()
                    .RemoveNodes();

                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 修改节点内容和属性
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void ModifyNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);

                XElement ele = xd.Descendants("class")
                     .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First();
                ele.Value = "This is a class";
                ele.Attribute("number").Value = "1";

                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 替换节点或内容
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void ReplaceNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);
                
                //将元素的子元素替换为新的内容 节点名仍保留，其他全部被替换
                XElement ele = xd.Descendants("class")
                   .Where(p => (string)p.Element("student").Attribute("id").Value == "01").First();
                xd.Descendants("class")
                        .Where(p => (string)p.Element("student").Attribute("id").Value == "01").Last()
                        .ReplaceAll(ele);
                //将元素属性替换为文本 元素名和子节点保留
                xd.Descendants("class")
                        .Where(p => (string)p.Element("student").Attribute("id").Value == "01").Last()
                        .ReplaceAttributes("123");
                //将元素子节点替换为新的内容 元素名和属性保留
                xd.Descendants("class")
                        .Where(p => (string)p.Element("student").Attribute("id").Value == "01").Last()
                        .ReplaceNodes("123");
                //将元素替换为新的内容 全都没有了
                xd.Descendants("class")
                        .Where(p => (string)p.Element("student").Attribute("id").Value == "01").Last()
                        .ReplaceWith("123");

                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 在当前文件中移动或复制节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void MoveOrCopyNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);
                //找出节点然后添加 如果是移动还要删除原来位置
                IEnumerable<XElement> ele = xd.Descendants("class")
                  .Where(p => (string)p.Element("student").Attribute("id").Value == "01");
                ele.ElementAt(0).Add(ele.ElementAt(1));
                xd.Save(xmlfile);
                
            }
        }

        /// <summary>
        /// 将节点复制到其他xml文件
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void CopyToOtherXmlNode(string xmlfile)
        {
            if (File.Exists(xmlfile))
            {
                XDocument xd = new XDocument();
                xd = XDocument.Load(xmlfile);

                IEnumerable<XElement> node = xd.Descendants("class");
                //把结果保存到单独的xml文件以进行观察
                XDocument xd_node = new XDocument(
                    new XElement("school",
                       node
                     )
                );
                xd_node.Save("node.xml");
            }
        }
    }

}
