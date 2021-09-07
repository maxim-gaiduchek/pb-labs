def main():
    m = float(input("Enter M: "))

    result = round((m - int(m)) * 1000) + int(m) / 1000

    print(result)


if __name__ == '__main__':
    main()
