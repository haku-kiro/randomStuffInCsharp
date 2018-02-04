import sys

sys.setrecursionlimit(10**6)
print("supposedly done")

def ack(m,n):
    ans = 0;
    if (m == 0):
        ans = n + 1
    elif (n == 0):
        ans = ack(m-1, 1)
    else:
        ans = ack(m-1, ack(m,n-1))
    return ans

for x in range(0,5):
    for y in range(0,5):
        print(ack(x,y))