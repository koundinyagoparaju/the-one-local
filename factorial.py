#This method returns the factorial of any no. (Yes!! Any no. even 50! and 100! too)
def factorial(num):
    carry=0
    product=str(1)
    partial_product=""
    for i in range(1,num+1):
        str_product=product[::-1]
        partial_product=""
        carry=0
        for k in range(0,len(str_product)):
            if k is len(str_product)-1:
                partial_product+=str((carry+(i*int(str_product[k]))))[::-1]
            else:
                partial_product+=str(carry+(i*int(str_product[k])))[-1]
                if(len(str(carry+(i*int(str_product[k]))))>1):
                    carry=int(str(carry+(i*int(str_product[k])))[:-1])
                else:
                    carry=0
        product=partial_product[::-1]
    return product

            
