string = 'abcd'
def change(old_str):
    old_str += 'x'
print(string)
change(string)
print(string)

a = 1
def change_int():
    a += 1
print(a)
change_int()
print(a)