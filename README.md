# TableTendersMVCService
* О сервисе
Сервис для демонстрации данных из Exel файла. При старте выводит окно с предложением авторизоваться или пройти регистрацию. 
После авторизации выводится данные из таблцы.

* Используемые технологии
Сервис работает на основе ASP NET Core. Для хранения данных пользователей и данных из Exel файла базы данных MS SQL, для работы
с ними ипользую расширения Microsoft.AspNetCore.Identity.EntityFrameworkCore (работа с базой полльзователей) и Microsoft.EntityFrameworkCore.SqlServe
(работа с базой данных получены из Exel файла). Для чтения данных из Exel файла использовал EPPlus.

* Идеи для улучшения, недостатки 
Не получилось прочитать данные из xls. Получилось только из xlsx. Необходим происледовать этот вопрос.