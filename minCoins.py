# The minimum no. of coins needed to make a value given the denominations of the available coins as a list
# a - list of denominations
# b - value of the no. for which the count is needed
# Eg: given coinList - [1,2,3,4] and val - 10   output: 4 (two 2's and two 3,s)
#fixes needed show -1 if the val cannot be made out of the given no.s
def minCoins(coinList,val):
	coinList.insert(0,0)
	minC={}
	minC[0]=0
	for l in range(1,val+1):
		minC[l]=9223372036854775807
	for i in range(val+1):
		for j in range(len(coinList)):
			if(coinList[j] <= i and minC[i-coinList[j]]+1 < minC[i]):
				minC[i]=minC[i-coinList[j]]+1
	if minC[val] is 9223372036854775807:
		minC[val]=-1
	print minC[val]
