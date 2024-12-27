### Название папки:
**`Ticket14_StringExpression`**

---

### Пример для проверки:

#### **Пример ввода:**
1. **Ручной ввод выражения:**
   ```
   Выберите источник выражения:
   1. Ввести выражение вручную
   2. Прочитать выражение из файла
   1
   Введите арифметическое выражение (например, 12 + 6): 15 / 3
   ```
   **Результат:**
   ```
   Результат: 5
   Введите имя файла для сохранения результата: output.txt
   Результат сохранен в файл: output.txt
   ```

2. **Содержимое файла `output.txt`:**
   ```
   Выражение: 15 / 3
   Результат: 5
   ```

---

#### **Пример файла для чтения:**
Создайте файл `input.txt` со следующим содержимым:
```
8 * 7
```

3. **Загрузка из файла:**
   ```
   Выберите источник выражения:
   1. Ввести выражение вручную
   2. Прочитать выражение из файла
   2
   Введите имя файла для чтения выражения: input.txt
   Выражение из файла: 8 * 7
   Результат: 56
   Введите имя файла для сохранения результата: output_result.txt
   Результат сохранен в файл: output_result.txt
   ```

4. **Содержимое файла `output_result.txt`:**
   ```
   Выражение: 8 * 7
   Результат: 56
   ```

---

### Проверка:
1. Введите значения, как в примерах выше.
2. Убедитесь, что результат вычисления корректен.
3. Проверьте корректность сохранения данных в выходной файл.

Если нужно дополнить пример или функциональность, дайте знать!