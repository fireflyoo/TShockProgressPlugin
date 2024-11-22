# TShockProgressPlugin
用来查询Boss进度的，用于TShock 泰拉瑞亚服务器的插件
## 指令
| 语法           |        权限         |   说明   |
| -------------- | :-----------------: | :------: |
| /progress | progress   | 进度查询 |

TShock游戏后台添加权限的具体指令：  
`/group addperm default progress`
## 编译指南
1. 克隆本仓库：`git clone https://github.com/fireflyoo/TShockProgressPlugin.git`
2. 进入本仓库目录：`cd TShockProgressPlugin`
3. 开始编译 `dotnet build`

## 已知Bug
1. 游戏客户端显示Boss列表不换行，导致文本超出屏幕范围不可读..
