using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//xml DOM
using System.Xml;
//xml file
using System.IO;

namespace CsharpFunction
{
    /*
     * 功能
     * DOM方法操作xml文件：创建xml文件 读取xml文件 查找节点或属性 增加节点或属性 删除节点或属性 修改节点或属性 替换节点或属性 移动或复制节点到当前文件 复制节点到其他xml文件
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
    class XmlDOM
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        public void CreateXml(string xmlfile)
        {
            if (!File.Exists(xmlfile))
            {
                //实例化XmlDocument对象
                XmlDocument xd = new XmlDocument();
                //xml文件的头文件声明
                XmlDeclaration declare = xd.CreateXmlDeclaration("1.0", "utf-8", "yes");
                xd.AppendChild(declare);
                //创建根节点
                XmlElement school = xd.CreateElement("school");
                school.SetAttribute("name", "new school");
                //创建一级子节点
                XmlElement fschool = xd.CreateElement("class");
                fschool.SetAttribute("number", "01");
                //创建二级第一个子节点
                XmlElement fclass = xd.CreateElement("student");
                fclass.SetAttribute("id", "01");
                fclass.SetAttribute("name", "Dan");
                fclass.SetAttribute("age", "18");
                //创建二级第二个子节点
                XmlElement sclass = xd.CreateElement("student");
                sclass.SetAttribute("id", "02");
                sclass.SetAttribute("name", "Tom");
                sclass.SetAttribute("age", "18");
                //添加节点到父节点，添加根节点到对象
                xd.AppendChild(school);
                school.AppendChild(fschool);
                fschool.AppendChild(fclass);
                fschool.AppendChild(sclass);
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 在文件中查找
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void SearchInXml(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);
                //查找固定名称 节点名要从根节点开始写
                XmlNode node_name = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");
                XmlElement ele_name = (XmlElement)node_name;
                //查找固定位置
                XmlNode node_position = xd.DocumentElement.SelectSingleNode("/school/class/student[position()=2]");
                XmlElement ele_position = (XmlElement)node_position;


                //保存到其他xml中测试上面的结果
                CopyToOtherXmlNode("dom.xml", "dom1.xml", node_name);
                CopyToOtherXmlNode("dom.xml", "dom1.xml", ele_name);
                CopyToOtherXmlNode("dom.xml", "dom1.xml", node_position);
                CopyToOtherXmlNode("dom.xml", "dom1.xml", ele_position);
            }
        }

        /// <summary>
        /// 追加节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void AppendNode(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);
                
                XmlNode node = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");
                
                //添加节点
                XmlElement ele = xd.CreateElement("sport");
                ele.InnerText = "football";
                //InsertAfter为在node后加,InsertBefore为在node前加，这两种增加后的节点与node同级
                //AppendChild为在node的最后一个子节点后再追加一个子节点，这种增加后的节点为node的子节点
                node.AppendChild(ele);
               
                //添加属性
                XmlElement nodee = (XmlElement)node;
                nodee.SetAttribute("gender", "male");

                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void DeleteNode(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);

                XmlNode node = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");
                
                xd.DocumentElement.FirstChild.RemoveChild(node);
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void ModifyNode(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);

                XmlNode node = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");

                node.InnerText = "node text";
                node.Attributes["age"].Value = "19";
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 替换节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void ReplaceNode(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);
                //如果用同一文件的节点替换，相当于删除被替换节点，将替换节点从原位置移动到被替换节点位置
                XmlNode node = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");
                XmlNode node2 = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='02']");
                xd.DocumentElement.FirstChild.ReplaceChild(node2, node);
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 在当前文件中移动或复制节点
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="nodename">节点属性名称</param>
        public void MoveOrCopyNode(string xmlfile, string nodename)
        {
            if (File.Exists(xmlfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);

                XmlNode node = xd.DocumentElement.SelectSingleNode("/school/class/student[@id='" + nodename + "']");
                ////在C#中从一个结构到另一个相同的结构，必须先取出节点然后使用import
                ////如从一个xml的节点到另一个xml需要用ImportNode
                ////如从一个databale的行到另一个databale需要用ImportRow
                XmlNode markNode = xd.ImportNode(node, true);
                //下面两句话可以用上面的ReplaceNode方法
                //如果是移动节点则取消下面这句话的注释：删除原节点  
                //xd.DocumentElement.FirstChild.RemoveChild(node);
                xd.DocumentElement.AppendChild(markNode);
                xd.Save(xmlfile);
            }
        }

        /// <summary>
        /// 将节点复制到其他xml文件
        /// </summary>
        /// <param name="xmlfile">包含路径和扩展名的文件名</param>
        /// <param name="desfile">包含路径和扩展名的目标文件名</param>
        /// <param name="movenode">要移动的节点</param>
        public void CopyToOtherXmlNode(string xmlfile, string desfile, XmlNode movenode)
        {
            if (File.Exists(xmlfile) && File.Exists(desfile))
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(xmlfile);

                XmlDocument xm = new XmlDocument();
                xm.Load(desfile);

                ////在C#中从一个结构到另一个相同的结构，必须先取出节点然后使用import
                ////如从一个xml的节点到另一个xml需要用ImportNode
                ////如从一个databale的行到另一个databale需要用ImportRow
                XmlNode markNode = xm.ImportNode(movenode, true);
                xm.DocumentElement.AppendChild(markNode);
                xm.Save(desfile);
            }
        }
    }
}
