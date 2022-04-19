from abc import ABC, abstractmethod


class Pair(ABC):

    def __init__(self, num1: int, num2: int):
        self.num1 = num1
        self.num2 = num2

    @abstractmethod
    def inc_num1(self):
        pass

    @abstractmethod
    def inc_num2(self):
        pass

    @abstractmethod
    def dec_num1(self):
        pass

    @abstractmethod
    def dec_num2(self):
        pass

    def is_not_zero(self):
        return self.num1 != 0 or self.num2 != 0


class Time(Pair):

    def inc_num1(self):
        self.num1 += 1

    def inc_num2(self):
        self.num2 += 1

        if self.num2 > 59:
            self.inc_num1()
            self.num2 = 0

    def dec_num1(self):
        self.num1 -= 1

    def dec_num2(self):
        self.num2 -= 1

        if self.num2 < 0:
            self.dec_num1()
            self.num2 = 59

    def __str__(self):
        return f"{self.num1} hours and {self.num2} minutes"


class Money(Pair):

    def inc_num1(self):
        self.num1 += 1

    def inc_num2(self):
        self.num2 += 1

        if self.num2 > 99:
            self.inc_num1()
            self.num2 = 0

    def dec_num1(self):
        self.num1 -= 1

    def dec_num2(self):
        self.num2 -= 1

        if self.num2 < 0:
            self.dec_num1()
            self.num2 = 99

    def __str__(self):
        return f"{self.num1} hryvnas and {self.num2} kopiykas"
