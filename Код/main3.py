def main():
    x, error = 0.56, 0.0001
    result, n = 0, 1

    element = func(x, n)

    while abs(element) > error:
        result += element
        n += 1
        element = func(x, n)

    print(result)


def func(x, n):
    return (1 if n % 2 == 0 else -1) * ((x ** (2 * n) + 1) / (2 ** n + 1))


if __name__ == '__main__':
    main()
