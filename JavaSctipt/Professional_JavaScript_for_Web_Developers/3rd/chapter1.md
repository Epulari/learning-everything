# 第一章 JavaScript简介
　　1、诞生于1995年，主要目的是处理以前由服务器端语言负责的一些输入验证操作。  
　　2、javascript之父：Brendan Eich（Netscape公司）。  
　　3、原名为LiveScript，为了赶上Java热的顺风车才改名。  
　　4、ECMAScript：基于js的新脚本语言。ECMA-262:ECMAScript的标准。  
　　5、Javascript的组成：核心ECMAScript、文档对象模型DOM、浏览器对象模型BOM。  
　　6、ECMAScript不包含输入输出定义，只是语言的基础，在此基础上可以构建更晚上的脚本语言。Web浏览器、Adobe Flash、Node是ECMAScript实现可能的宿主环境，宿主环境既提供基本的ECMAScript实现，又该语言的扩展，以便语言和环境之间对接交互。扩展如DOM，利用ECMAScript的核心类型和语法提供更多具体的功能，以便实现针对环境的操作。  
　　7、ECMA-262规定语言组成部分为：语法、类型、语句、关键字、保留字、操作符、对象。ECMAScript是对实现该标准规定的各个方面内容的语言的描述。Javascript实现了ECMAScript，Adobe ActionScript也实现了ECMAScript。第三版标志着ECMAScript成为了一门真正的编程语言。  
　　8、IE对ECMAScript兼容性：IE5第一版，IE5.5-IE7第三版，IE8第五版不完全兼容的实现，IE9+第五版。  
　　IE对DOM的支持：IE5一级最小限度，IE5.5-IE8一级最小限度几乎全部，IE9+一级二级三级。  
　　9、文档对象模型（Document Object Model, DOM）是针对XML但经过扩展用于HTML的应用程序编程接口（Application Programming Interface, API）。也即提供访问和操作网页内容的方法和接口。DOM把整个页面映射为一个多层节点结构。  
　　10、W3C（World Wide Web Consortium, 万维网联盟）：制定Web通信标准。  
　　11、使用浏览器对象模型（Browser Object Model, BOM）可以控制浏览器显示的页面以外的部分。也即是提供与浏览器交互的方法和接口。  