from math import factorial


def main():
    x = float(input("Enter x: "))
    n = int(input("Enter n: "))

    print(sum([func(x, i) for i in range(1, n + 1)]))


def func(x, n):
    return x ** (n - 1) / factorial(n - 1)


if __name__ == '__main__':
    main()
