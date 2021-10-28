from math import log10


def main():
    for num in range(10, 10000):
        length = int(log10(num)) + 1
        ams = 0

        for p in range(length):
            ams += (int(num / 10 ** p) % 10) ** length

        if num == ams:
            print(num, end=", ")


if __name__ == '__main__':
    main()
