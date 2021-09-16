def main():
    m = float(input("Enter M: "))

    a = int(m)
    b = m - a

    result = a / 1000. + round(b * 1000)

    print(result)


if __name__ == '__main__':
    main()
