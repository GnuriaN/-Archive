﻿# SMARTHDD
> Программа для чтения S.M.A.R.T. с использованием WMI.

#### Структура программы
> Класс Smart.cs
* описание объекта атрибута S.M.A.R.T.

> Класс BlockDevices.cs 
* описание объекта жёсткого диска
	
> Класс BlockDevicesSmart.cs
* описание объекта содержащего информацию о дисках и состояние атрибутов

> Program.cs 
* Основная программа

#### Ограничения:
> Программа может получать информацию только через WMI, а это накладывает ограничения. Можно получить только информацию, которая подключена напрямую к ПК через интерфейсы SATA и/или IDE. Диски, подключаемые через USB, не определяются.

#### Результат работы:
![Изображение окна с результатом работы SMARTHDD.EXE](http://savepic.ru/9805870.png "окно с результатом работы SMARTHDD.EXE")