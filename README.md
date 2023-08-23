# 冰道助手

![.NET](https://img.shields.io/badge/.NET-6.0-blue)
[![license](https://img.shields.io/badge/license-GPL--3.0-orange)](LICENSE.txt)
[![SharpNBT](https://img.shields.io/badge/SharpNBT-1.2.0-green)](https://github.com/ForeverZer0/SharpNBT)
[![Release](https://img.shields.io/badge/Release-1.0.0-00BFBF)](https://github.com/glowstone314/Ice_Highway_Helper/releases/latest)
![Minecraft](https://img.shields.io/badge/Minecraft-Java-lightgray)

[![Bilibili](https://img.shields.io/badge/Bilibili-Glow__Creeper-009F9F?logo=Bilibili)](https://space.bilibili.com/272246604)

在游戏Minecraft中，玩家通常会建造与x或z轴平行的冰道，并使用护栏防止玩家脱轨。冰道助手可以帮你建造斜向的冰道，即使是非45°整数倍的角度，且不需要护栏。

## 使用

在原版游戏中，玩家坐上船后，船的方向会对齐为1.40625°的整数倍（即：将360°等分为256份）。

将你的起点与目的地输入冰道助手，点击“生成”按钮即可计算出冰道的设计方案。点击“保存投影”按钮获取冰道原理图后，在游戏中使用[Tweakeroo](https://github.com/maruohon/tweakeroo/)模组的“辅助瞄准(Snap Aim)”功能，将玩家视角限定为1.40625°的整数倍，按冰道助手给出的角度放下船，坐上船笔直前进，即可顺利到达目的地。

由于船的稳定角度被限制在1.40625°的整数倍，实际建造时可能冰道终点与目的地之间有偏差。当偏差大于4时，即可选择建造“分段式冰道”，将冰道拆为两部分，每个部分都与1.40625°的整数倍对齐，只需在行进至两段冰道的交点时重新放置一次船，就能实现冰道终点与目的地完全一致。

## 安装

需要Windows操作系统与[.NET 6.0环境](https://dotnet.microsoft.com/zh-cn/download/dotnet/6.0)

[下载](https://github.com/glowstone314/Ice_Highway_Helper/releases/latest)后解压，打开“Ice_Highway_Helper.exe”即可使用。

## 库

- [SharpNBT](https://github.com/ForeverZer0/SharpNBT): 读写NBT数据的C#库，使用[MIT开源协议](LICENSE_SharpNBT.txt)