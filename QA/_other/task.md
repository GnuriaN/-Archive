# Маленькая задача

> **задача в виде**: у нас есть программа, которая принимает 3 числа. это стороны треугольника. и на выходе говорит, какой это треугольник - равнобедренный, равносторонний или прямоугольный. как бы вы это тестировали?

**Стороны** A, B, C.

## Равносторонний

- A = B = C

## Равнобедренный

- A = B и 0 < C < A + B
- A = C и 0 < B < A + C
- B = C и 0 < A < B + C

## Прямоугольный

A = SQR(B^2 + C^2)
B = SQR(A^2 + C^2)
C = SQR(A^2 + B^2)

### Тесты для проверки правильности

| № | A | B | C | Предполагаемый ответ |
|:-:|:-:|:-:|:-:|:--|
|1)| 10.1 | 10.1 | 10.1 | Равносторонний |
|2)| 3    | 4    | 5    | Прямоугольный  |
|3)| 10   | 8    | 6    | Прямоугольный  |
|4)| 0.6  | 1    | 0.8  | Прямоугольный  |
|5)| 10   | 10   | 4    | Равнобедренный |
|6)| 11.1 | 5    | 11.1 | Равнобедренный |
|7)| 8.4  | 5    | 5    | Равнобедренный |

### Тесты для проверки ошибки

| № | A | B | C | Комментарий |
|:-:|:-:|:-:|:-:|:--|
|0)| 0    | 0    | 0    | Это ^_^ |
|1)| 1.1  | 1.2  | 1.3  | Это просто треугольник |
|3)| 10   | 10   | 20   | Это вырожденный треугольник |
|4)| "10" | "10" | "10" | Это просто три строки |
|5)| -0.8 | -0.6 | 1    | Это нечто, но не треугольник |
|6)| 2    | 2    | 5    | Это нечто, но не треугольник |
|7)| -1.2 | -1.2 | -1.2 | Это нечто, но не треугольник |

### Тесты чтобы "сломать"

| № | A | B | C | Комментарий |
|:-:|:-:|:-:|:-:|:--|
|1)| 65534| 65534| 65533| Если есть переполнение int (16 bit) сумма равна 65532, что меньше 65533 и следовательно треугольник не возможен. Но это не так. Схожие тесты на переполнения друх пипов данных.|
|2)| ||||