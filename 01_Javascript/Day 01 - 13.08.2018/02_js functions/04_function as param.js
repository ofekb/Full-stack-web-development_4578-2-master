function execFunc(f1,f2){
    (Date.now()%2==0)?f1(Date.now(),"even"):f2(Date.now(),"odd");
}

execFunc(
    (num,msg)=>console.log(num*2,num,msg),
    (num,msg)=>console.log(num**2,num,msg)
);


/*
OPTIONAL OUTPUTS:
________________________

2.3499093106048104e+24 1532941391771 'odd'

3065882784276 1532941392138 'even'
*/