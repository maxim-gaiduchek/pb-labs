text = input()
n = int(input())

for s in text.split(" "):
    if len(s) == n:
        print(s, end=", ")
