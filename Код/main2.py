def main():
    x, y = float(input("Enter x: ")), float(input("Enter y: "))

    if abs(y) >= x ** 2 and abs(x) >= y ** 2:
        print(f"The figure contains the point ({x}; {y})")
    else:
        print(f"The figure does not contain the point ({x}; {y})")


if __name__ == '__main__':
    main()
