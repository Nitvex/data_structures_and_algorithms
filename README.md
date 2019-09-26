# [ИТМО] Курс по структурам данных и алгоритмам

##### Лабораторная 1:  Основные определения и поиск в ширину.
   
   > Задача А. От списка ребер к матрице смежности. Простой ориентированный граф задан списком ребер, выведите его представление в виде матрицы смежности

   > Задача B. Проверка на неориентированность. По заданной квадратной матрице NxN из нулей и единиц, определите может ли данная матрица быть матрицей смежности простого неориентированного графа.

   > Задача C. Проверка на наличие параллельных ребер, неориентированный граф. Неориентированный граф задан списком ребер. Проверьте, содержит ли он параллельные ребра.

   > Задача D. Компоненты связности. Дан неориентированный граф. Требуется выделить компоненты связности в нем. Подсказка: для решения задачи можно воспользоваться поиском в ширину или поиском в глубину.

   > Задача E. Кратчайший путь в невзвешенном графе. Дан неориентированный невзвешенный граф. Найдите кратчайшее расстояние от первой вершины до всех вершин.

   > Задача F. Лабиринт. Лабиринт представляет собой поле NxM. По некоторым его клеткам ходить можно, а по некоторым - нет. Узник находится в одной из клеток лабиринта и может перемещаться за ход на одну из четерех соседних клеток. Помогите ему дойти до выхода за минимальное число шаов или сообщите, что выйти невозможно.
##### Лабораторная 2: Поиск в глубину.
   > Задача А. Топологическая сортировка. Дан ориентированный невзвешенный граф. Необходимо его топологически отсортировать.

   > Задача B. Поиск цикла. Дан ориентированный невзвешенный граф. Необходимо определить есть ли в нем циклы, и если есть, то вывести любой из них.

   > Задача С. Двудольный граф. Двудольным называется неориентированный граф {V,E}, вершины которого можно разбить на два множества L и R, так что LnR=пустое множество, LuR=V и для любого ребра (u,v) принадлежит E, либо u принадлежит L, v принадлежит R, либо v принадлежит L, u принадлежит R.

   > Задача D. Конденсация графа. Дан ориентированный невзвешенный граф. Необходимо выделить в нем компоненты сильной связности и топологически их отсортировать.

   > Задача E. Гамильтонов путь. Дан ориентированный граф без циклов. Требуется проверить, существует ли в нем путь, проходящий по всем вершинам.

   > Задача F. Игра. Дан ориентированный невзвешенный ациклический граф. На одной из вершин графа стоит "фишка". Двое играют в игру. Пусть "фишка" находится в вершине u, и в графе есть ребро (u,v). Тогда за ход разрешается перевести "фишку" из вершины u в вершину v. Проигрывает тот, кто не может сделать ход.
##### Лабораторная 3: Минимальные остовные деревья. 
   > Задача А. Степени вершин. Неориентированный граф задан списком ребер. Найдите степени всех вершин графа.

   > Задача B. Остовное дерево. Даны точки на плоскости, являющиеся вершинами полного графа. Вес ребра равен расстоянию между точками, соответствующими концам этого ребра. Требуется в этом графе найти остовное дерево минимального веса.

   > Задача С. Остовное дерево. Требуется найти в связном графе остовное дерево минимального веса.

   > Задача D. Алгоритм двух китайцев. Дан ориентированный взвешенный граф. Покрывающим деревом с корнем в вершине u назовем множество ребер, таких что из вершины u достижима любая другая вершина v, притом единственным образом. Весом дерева назовем сумму его ребер. Требуется определить, существует ли в данном графе покрывающее дерево с корнем в вершине с номером 1. В случае существования требуется определить его минимальный вес.

   ##### Лабораторная 4: Кратчайшие пути в графах.

   > Задача А. Кратчайший путь. Дан ориентированный взвешенный граф. Найдите кратчайшее расстояние от одной заданной вершины до другой.

   > Задача B. Кратчайший путь от каждой вершины до каждой. Задан ориентированный взвешенный связный граф. Найдите матрицу расстояний между его вершинами.

   > Задача С. Кратчайший путь. Дан неориентированный взвешенный граф. Найдите кратчайшее расстояние от первой вершины до всех вершин.

   > Задача D. Кратчайшие пути и прочее. Дан взвешенный ориентированный граф и вершина s в нем. Требуется для каждой вершины u найти длину кратчайшего пути из s в u.

   > Задача E. Цикл отрицательного веса. Дан ориентированный взвешенный граф. Определить, есть ли в нем цикл отрицательного веса, и если да, то вывести его.

   ##### Лабораторная 5: Потоки в графах.

   > Задача А. Максимальный поток. Задан ориентированный граф, каждое ребро которого обладает целочисленной пропускной способностью. Найдите максимальный поток из вершины с номером 1 в вершину с номером n.

   > Задача B. Паросочетание. Дан двудольный невзвешенный граф. Необходимо найти максимальное паросочетание.

   > Задача С. Декомпозиция потока. Задан ориентированный граф, каждое ребро которого обладает целочисленной пропускной способностью. Найдите максимальный поток из вершины с номером 1 в вершину с номером n и постройте декомпозицию потока.

   > Задача D. Циркуляция. Назовем циркуляцией поток величины 0. Дан ориентированный граф с нижними и верхними пропускными способностями, то есть для любых вершин i и j должно быть верно, что Lij <= Fij <= Cij, где Lij - нижняя граница, а Cij - верхняя. Требуется найти циркуляцию в данном графе, удовлетворяющую данным ограничениям.

##### Лабораторная 6: Поиск подстрок.
> Задача А. Наивный поиск подстроки в строке. Даны строки p и t. Требутеся найти все вхождения строки p в строку t в качестве подстроки.

> Задача B. Наивный поиск подстроки в строке. Даны строки p и t. Требутеся найти все вхождения строки p в строку t в качестве подстроки.

> Задача С. Префикс-функция. Постройте префикс-функцию для заданной строки s.