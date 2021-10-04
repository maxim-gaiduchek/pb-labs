def main():
    a, b, c = int(input("Enter a: ")), int(input("Enter b: ")), int(input("Enter c: "))
    print(gcd(gcd(a, b), c))


def gcd(a, b):
    while a % b != 0 and b % a != 0:
        if a > b:
            a %= b
        else:
            b %= a

    return min(a, b)


if __name__ == '__main__':
    main()
