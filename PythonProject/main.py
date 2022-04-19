import random

from classes import Time, Money

n = random.randint(2, 10)
summ = Money(0, 0)

for _ in range(n):
    time = Time(random.randint(0, 7), random.randint(0, 59))
    money = Money(random.randint(0, 10), random.randint(0, 99))

    print("Time:", time)
    print("Money:", money)
    print("Sum:", summ)
    print()

    while time.is_not_zero():
        temp = Money(money.num1, money.num2)

        while temp.is_not_zero():
            summ.inc_num2()
            temp.dec_num2()

        time.dec_num2()

print("Sum:", summ)
