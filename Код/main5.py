def main():
    length = 2

    for num in range(10, 10000):
        if num == 100 or num == 1000:
            length += 1

        ams = 0

        for i in range(length):
            ams += (int(num / 10 ** i) % 10) ** length

        if num == ams:
            print(num)


if __name__ == '__main__':
    main()
