path = "file.txt"

with open(path, "a") as file:
    while True:
        line = input()

        if len(line) > 0:
            file.write(line + "\n")
        else:
            break

with open(path, "r") as file:
    print("File text:")

    for line in file:
        print(line, end="")

text = ""
with open(path, "r") as file:
    count = 1

    for line in file:
        if line[-1] == "\n":
            line = line[:-1]

        if count % 2 == 1:
            digits = 0

            for ch in line:
                if ord("0") <= ord(ch) <= ord("9"):
                    digits += 1

            line += " " + str(digits)

        count += 1
        text += line + "\n"

with open(path, "w") as file:
    file.write(text)

with open(path, "r") as file:
    print("Parsed file text:")

    for line in file:
        print(line, end="")
