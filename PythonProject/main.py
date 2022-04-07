import random

from Matrix import Matrix

n = random.randint(2, 5)
arr = [[random.randint(0, 9) for _ in range(n)] for _ in range(n)]

mat1 = Matrix(n)
mat2 = Matrix(arr)

print("M1:")
print(mat1)
print("M2:")
print(mat2)

mat3 = mat1 + mat2

print("M3:")
print(mat3)

mat3 *= mat3

print("New M3:")
print(mat3)

print("New M3's norm:")
print(mat3.get_norm())
