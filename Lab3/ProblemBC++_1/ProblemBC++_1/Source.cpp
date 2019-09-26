#include <stdio.h>
#include <math.h>
#include <vector>
class Point {
public:
	int x;
	int y;

	Point(int _x, int _y) {
		x = _x;
		y = _y;
	}

	double vectorLength(Point p) {
		return ((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y));
	}
};
void main() {
	using namespace std;
	freopen("spantree.in", "r", stdin);
	freopen("spantree.out", "w", stdout);
	int n;
	scanf("%d", &n);	
	Point* points = (Point*)malloc(sizeof(Point) * n);
	//vector<Point> points(n);
	int tempX, tempY;
	for (int i = 0; i < n; i++) {
		scanf("%d %d", &tempX, &tempY);		
		points[i] = Point(tempX, tempY);
	}
	bool* isOutOfTree = new bool[n];
	int* lenghts = new int[n]; 
	isOutOfTree[0] = false;
	for (int i = 1; i < n; i++) {
		lenghts[i] = points[0].vectorLength(points[i]);
		isOutOfTree[i] = true;
	}
	double MSTWeight = 0; 
	int min, length;
	int last = 0; 
	int count = 1;
	while (count < n) {		
		min = INT_MAX;		
		for (int p = 1; p < n; p++) {
			if (lenghts[p] < min && isOutOfTree[p]) {
				min = lenghts[p];
				last = p;
			}
		}	
		isOutOfTree[last] = false;
		MSTWeight += sqrt(min);
		count++;
		for (int p = 1; p < n; p++) {
			if (isOutOfTree[p]) {			
				length = points[last].vectorLength(points[p]);
				if (length < lenghts[p]) {
					lenghts[p] = length;
				}
			}
		}
	}
	printf("%.3lf\n", MSTWeight);
}