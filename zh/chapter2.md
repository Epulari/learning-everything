# 第二章 在HTML中使用JavaScript
1、&lt;script&gt;&lt;/script&gt;的属性：  
async: 解析DOM的同时下载脚本，然后立即执行脚本。动态脚本默认为真。  
charset: 通过src属性指定的代码的字符集  
defer: 解析DOM的同时下载脚本，DOM解析完成后执行脚本  
src: 要引入的外部代码文件  
type: 编写代码使用的脚本语言的内容内行（即MIME类型）。text/javascript和text/ecmascript已经不推荐使用，但前者一直在使用。服务器传送的其实是application/x-javascript，但html可能不会解析它。非IE可以用application/javascript和application/ecmascript。考虑到约定和兼容，目前type默认属性值依旧为text/javascript，因此可以不指定。
2、async/defer:bool，前者指示浏览器是否在允许的情况下异步执行该脚本；后者被设定用来通知浏览器该脚本将在文档完成解析后，触发DOMContentLoaded事件前执行。都对内联脚本无作用（即没有src属性的脚步）。  
3、一般理解，XHTML是更严格的HTML，编写更加规范。  
4、在现实当中，延迟脚本defer并不一定会按照顺序执行，也不一定会在DOMContentLoaded事件触发前执行，因此最好只包含一个延迟脚本。  
5、HTML5中明确规定，不支持嵌入脚本的defer属性，它只适用于外部脚本。但IE4-IE7支持嵌入脚本的defer属性。  
6、HTML5中明确规定，不支持嵌入脚本的async属性，它只适用于外部脚本。它不保证脚本按照指定的先后顺序执行，但一定会在页面的load事件前执行，但DOMContentLoaded事件触发的前后都可能。  
7、ECMA-262规定语言组成部分为：语法、类型、语句、关键字、保留字、操作符、对象。ECMAScript是对实现该标准规定的各个方面内容的语言的描述。Javascript实现了ECMAScript，Adobe ActionScript也实现了ECMAScript。第三版标志着ECMAScript成为了一门真正的编程语言。  
8、IE对ECMAScript兼容性：IE5第一版，IE5.5-IE7第三版，IE8第五版不完全兼容的实现，IE9+第五版。  
IE对DOM的支持：IE5一级最小限度，IE5.5-IE8一级最小限度几乎全部，IE9+一级二级三级。  
9、文档对象模型（Document Object Model, DOM）是针对XML但经过扩展用于HTML的应用程序编程接口（Application Programming Interface, API）。也即提供访问和操作网页内容的方法和接口。DOM把整个页面映射为一个多层节点结构。  
10、W3C（World Wide Web Consortium, 万维网联盟）：制定Web通信标准。  
11、使用浏览器对象模型（Browser Object Model, BOM）可以控制浏览器显示的页面以外的部分。也即是提供与浏览器交互的方法和接口。  
**思考：**
1、async执行时间、执行顺序不确定，因此最好只用于与其他脚本无关的脚本。并不是所有浏览器都支持defer。
2、script使用src属性指向外部域时存在安全隐患。