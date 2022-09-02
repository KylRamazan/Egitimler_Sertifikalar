# Veri Yapiları ve Algoritmalar
## Insertion Sort - Proje 1
[22,27,16,2,18,6] -> Insertion Sort

1. Yukarıda verilen dizinin sort türüne göre aşamalarını yazınız.
``` 
1.Aşama => [22,27,16,2,18,6] - (n)
2.Aşama => [16,22,27,2,18,6] - (n-1)
3.Aşama => [2,16,22,27,18,6] - (n-2)
4.Aşama => [2,16,18,22,27,6] - (n-3)
5.Aşama => [2,6,16,18,22,27] - (n-4)
```
2. Big-O gösterimini yazınız.
```
0(n²)
```

3. Time Complexity
```
Average Case
[2,6,16,18,22,27] => 16,18 - O(n²)
Worst Case
[2,6,16,18,22,27] => 27 - O(n²)
Best Case 
[2,6,16,18,22,27] => 2 - O(n)
```
4. Dizi sıralandıktan sonra 18 sayısı hangi case kapsamına girer? 
```
Average case kapsamına girer.
```
5. [7,3,5,8,2,9,4,15,6] dizisinin Insertion Sort'a göre ilk 4 adımını yazınız.
```
1.Aşama => [3,7,5,8,2,9,4,15,6]
2.Aşama => [3,5,7,8,2,9,4,15,6]
3.Aşama => [3,5,7,8,2,9,4,15,6]
4.Aşama => [2,3,5,7,8,9,4,15,6]
```