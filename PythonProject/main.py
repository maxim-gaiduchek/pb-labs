path = "file.txt"

with open(path, "a") as file:
    print("Enter text:")

    while True:
        line = input()

        if len(line) > 0 and line[0] == chr(25):  # CTRL + Y
            break
        else:
            file.write(line + "\n")

    print()

with open(path, "r") as file:
    print("File text:")

    for line in file:
        print(line, end="")

    print()

text = ""
with open(path, "r") as file:
    count = 1

    for line in file:
        line = line.strip()

        if count % 2 == 1:
            digits = 0

            for ch in line:
                if ord("0") <= ord(ch) <= ord("9"):
                    digits += 1

            line += " " + str(digits)

        count += 1
        text += line + "\n"

    print()

with open(path, "w") as file:
    file.write(text)

with open(path, "r") as file:
    print("Parsed file text:")

    for line in file:
        print(line, end="")
