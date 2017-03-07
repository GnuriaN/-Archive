# Адрес сервера с по для сервера СЛК
[string]$UrlPath = "http://www.vdgb-soft.ru/faq/faq_tsj_3_0/обновление_системы_лицензирования/"
# Необходимая версия сервера СЛК
[string]$File = "_Protection_2.1.7.435.zip"
# Путь для установки
[string]$InstallPath = "c:\!test"
# Файл параметров для установки Сервера СЛК

# Скачиваем необходимый дистрибутив
"Downloads $File from $UrlPath"
Invoke-WebRequest "$UrlPath$File" -OutFile "$env:TEMP\$File" -UseBasicParsing
# Разпаковываем его по заданному пути
"Expand archive $file"
Expand-Archive -Path "$env:TEMP\$file" -DestinationPath "$InstallPath" -Force
# Переходим в место где находятся установочные файлы
cd "$InstallPath\$(ls "$InstallPath" -name)"
# Запускаем установку
"Install License Server..."
.\LicenceServer-2.1.7.435-Setup.exe /verysilent /Components=licenceserver /Tasks=service
"Done!"
# Устанавливаем драйвер ключа
.\upkeyx-10.1.11.686-r517.win.exe  /i /fe
"Done!"
# 
"Install complite"
