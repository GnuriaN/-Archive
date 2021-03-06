# Continuous Integration

> Путь обеспечения надежности и доверия к системе

_**Continuous Integration** (далее **CI**)_ — это практика разработки программного обеспечения, в которой члены команды проводят интеграцию не реже чем раз в день. Результаты интеграции проверяются автоматически, используя автотесты и статический анализ кода.

Использование **CI** позволяет вовремя отслеживать ошибки интеграции, сделать систему и процесс разработки более «прозрачными» для всех участников команды, также, **CI** избавляет от рутинных операция по сборке продукта, повышает качество продукта, включает в себя профит от написания тестов.

Фактически, **CI** позволяет избавиться от предположений, при процессе разработки ПО. Менеджер предполагает, что продукт готов и стабилен, программист — что в коде нет ошибок и т. д. Избавиться от вопросов, таких как: «стабильна ли последняя сборка, какие фичи готовы, соответствует ли код стандартам компании» и т.д.

Идеологически CI базируется на следующих соглашениях:

- регулярно «заливать» свой код в репозиторий;
- писать автоматические тесты;
- запускать private builds (процесс сборки, который выполняется с использованием исходного кода, в данный момент находящегося в локальном репозитории разработчика);
- не «заливать» неработающий код;
- чинить сломанный build немедленно;
- следить за тем, чтобы все тесты и проверки проходили;
- не выкачивать из репозитория сломанный код.

## Build script

_Скрипт сборки (**Build script**)_ — это набор комманд, которые будут выполнены при запуске процесса интеграции. Чаще всего он выглядит как следующий набор шагов:

- Очистка от результатов предидущего запуска;
- Компиляция (или статический анализ кода для интерпретируемых языков);
- Интеграция с базой данных;
- Запуск автоматических тестов;
- Запуск других проверок (соответствие код стандартам, проверка цикломатической сложности и т. д.);
- Разворачивание программного обеспечения.

После того как **Build script** отработал возможно два варианта:

- сборка прошла успешно;
- сборка не прошла и нужно починить или исправить ошибки.

## Автоматические тесты

Автоматические тесты это неотъемлемая часть процесса непрерывной интеграции. И один лишь статический анализ кода в автоматическом режиме не является **Continuous Integration**, такой подход называют **Continuous Compilation**.

В **CI** используются тесты всех уровней за исключением исследовательских. Так как на разных ресурсах список уровней тестирования разный приведу те, которые описывают идеологи **CI**:

- модульные (unit) тесты
- компонентные тесты
- функциональные тесты
- системные тесты

По написанию и запуску тестов также принят ряд соглашений:

- более быстрые тесты должны запускаться первыми;
- тесты должны быть разделены по категориям;
- на все баги должны писаться тесты;
- тест кейсы стоит ограничивать одной проверкой;
- тесты должны выполняться без ошибок при повторном запуске.

## Continuous Inspection

**Continuous Inspection** — это один из шагов **build script**, который предполагает проверку соответствия кода в репозитории код стандартам, соответствие уровня code coverage и других метрик заданному порогу.

## Continuous Feedback

Одним из самых важных действий в **CI** является механизм обратной связи, который согласно положениям **CI**, должен осуществляться с учетом правила: «Правильным людям. В правильное время. Правильным образом.» (ориг. — _«The right people. The right time. The right way.»_).

Существуют следующие популярные механизмы осуществления обратной связи:

- SMS;
- browser plug-in;
- светофор сборок;
- звуковое оповещение;
- email;

Также, стоит отметить, что многие IDE позволяют синхронизироваться с популярными (Jenkins, TeamCity) CI серверами.
