import random


class Matrix:

    def __init__(self, var):
        if type(var) is int:
            self.coefficients = [[random.randint(0, 9) for _ in range(var)] for _ in range(var)]
        elif type(var) is list:
            self.coefficients = var

    def get_norm(self):  # l-norm, by cols
        result = 0

        for j in range(len(self.coefficients[0])):
            summ = sum(map(lambda arr: arr[j], self.coefficients))

            if j == 0 or result < summ:
                result = summ

        return result

    def __add__(self, other):
        n = len(self.coefficients)
        result = [[0 for _ in range(n)] for _ in range(n)]

        for i in range(n):
            for j in range(n):
                result[i][j] = self.coefficients[i][j] + other.coefficients[i][j]

        return Matrix(result)

    def __mul__(self, other):
        n = len(self.coefficients)
        result = [[0 for _ in range(n)] for _ in range(n)]

        for i in range(n):
            for j in range(n):
                for a in range(n):
                    result[i][j] += self.coefficients[i][a] * other.coefficients[a][j]

        return Matrix(result)

    def __str__(self):
        result = ""

        for row in self.coefficients:
            for num in row:
                result += str(num) + "\t"

            result += "\n"

        result += "\n"

        return result
