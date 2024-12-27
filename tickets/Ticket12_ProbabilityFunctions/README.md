### Название папки:
**`Ticket12_ProbabilityFunctions`**

---

### Пример для проверки:

#### **Ввод:**
```
Введите количество объектов (n): 5
Введите количество объектов для выборки (k): 3
```

---

#### **Ожидаемый вывод:**
```
Число перестановок (Pn): 120
Число размещений (An): 60
Число сочетаний (Cn): 10
```

---

### Подробности вычислений:

1. **Перестановки (Pn):**
    - Формула: \( P_n = n! \)
    - Расчет: \( 5! = 5 \times 4 \times 3 \times 2 \times 1 = 120 \)

2. **Размещения (An):**
    - Формула: \( A_k^n = \frac{n!}{(n-k)!} \)
    - Расчет: \( A_3^5 = \frac{5!}{(5-3)!} = \frac{120}{2} = 60 \)

3. **Сочетания (Cn):**
    - Формула: \( C_k^n = \frac{n!}{(n-k)! \cdot k!} \)
    - Расчет: \( C_3^5 = \frac{5!}{(5-3)! \cdot 3!} = \frac{120}{2 \cdot 6} = 10 \)

---

### Проверка:
1. Введите значения \( n \) и \( k \) для тестирования.
2. Проверьте, что результаты совпадают с расчетами вручную.
3. Если хотите протестировать с большими значениями \( n \) и \( k \), убедитесь, что они подходят для диапазона `long` (максимум около 20!).

Если нужно уточнить или добавить что-то, дайте знать!