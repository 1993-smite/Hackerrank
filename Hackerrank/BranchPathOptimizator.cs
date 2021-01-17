/// <summary>Оптимизация маршрута с помощью алгоритма ветвления и границ</summary>
    public class BranchPathOptimizator: IPathOptimizator {

        public PathLine OptimizePath(PathLine cluster) { 
            PathLine line = new PathLine(new List<PathPoint>());

            //Построение матрицы расстояний между точками
            double[,] lengths = new double[cluster.Points.Count, cluster.Points.Count];
            for (int i=0; i<cluster.Points.Count; i++) {
                for (int j=0; j<cluster.Points.Count; j++) {
                    if (i==j) lengths[i,j] = Double.MaxValue;
                    else if (i>j) lengths[i,j] = lengths[j,i];
                    else lengths[i,j] = cluster.Points[i].GetDistance(cluster.Points[j]);
                }
            }

            int pointsCount = cluster.Points.Count;
            while (cluster.Points.Count > 1) { // проход алгоритма с уменьшением размерности матрицы расстояний
                    
                // приведение матрицы
                int optI, optJ;
                double koef1 = Adduction(lengths, out optI, out optJ);

                double tmp = lengths[optJ, optI]; // для создания уменьшенной матрицы
                lengths[optJ, optI] = Double.MaxValue;
                    
                // уменьшение матрицы
                double[,] buf = new double[cluster.Points.Count-1, cluster.Points.Count-1];
                for (int i=0; i<buf.GetLength(0); i++) { // убираются строки
                    for (int j=0; j<buf.GetLength(0); j++) {
                        if (i>=optI) buf[i,j] = lengths[i+1,j];
                        else buf[i,j] = lengths[i,j];
                    }
                }
                for (int i=0; i<buf.GetLength(0); i++) { // убираются столбцы
                    for (int j=0; j<buf.GetLength(0); j++) {
                        if (j>=optJ && i>=optI) buf[i,j] = lengths[i+1,j+1];
                        else if (j>=optJ) buf[i,j] = lengths[i,j+1];
                    }
                }

                lengths[optJ, optI] = tmp;
                    
                // приведение матрицы во второй ветви
                double[,] lengths2 = (double[,])buf.Clone();
                double koef2 = Adduction(lengths2, out optI, out optJ);

                if (koef2<koef1 || cluster.Points.Count==2) { // добавляем точку и переходим к меньшей матрице
                    line.Points.Add( cluster.Points[optI] );
                    cluster.Points.RemoveAt(optI); // устраняет смещение индексов для выбора новых точек
                    lengths = buf;
                }
            }

            line.Points.Add( cluster.Points[0] );   

            return line;
        }

        /// <summary>Опреация приведения, возвращает приведенную матрицу, обобщенный коэффициент приведения, его индексы</summary>
        private double Adduction(double[,] lengths, out int optI, out int optJ) {
            // редукция строк
            double[] minStr = new double[lengths.GetLength(0)];
            for (int i=0; i<lengths.GetLength(0); i++) {
                minStr[i] = Double.MaxValue;
                for (int j=0; j<lengths.GetLength(0); j++) 
                    if (lengths[i,j] < minStr[i]) minStr[i] = lengths[i,j];
                for (int j=0; j<lengths.GetLength(0); j++) 
                    lengths[i,j] -= minStr[i];
            }

            // редукция столбцов
            double[] minCln = new double[lengths.GetLength(0)];
            for (int j=0; j<lengths.GetLength(0); j++) {
                minCln[j] = Double.MaxValue;
                for (int i=0; i<lengths.GetLength(0); i++) 
                    if (lengths[i,j] < minCln[j]) minCln[j] = lengths[i,j];
                for (int i=0; i<lengths.GetLength(0); i++) 
                    lengths[i,j] -= minCln[j];
            }

            // определение ребра ветвления
            optI=0; optJ=0;
            double maxKoef = 0;
            for (int i=0; i<lengths.GetLength(0); i++) {
                for (int j=0; j<lengths.GetLength(0); j++) {
                    if (lengths[i,j]==0) {
                        double koef = minStr[i] + minCln[j];
                        if (koef > maxKoef) {
                            maxKoef = koef;
                            optI = i;
                            optJ = j;
                        }
                    }
                }
            }

            // определение обобщенного коэффициента приведения
            double koef1 = maxKoef;
            for (int i=0; i<minStr.Length; i++) koef1 += minStr[i] + minCln[i];

            // вычеркивание элемента с максимальным коэффициентом приведения
            lengths[optI, optJ] = Double.MaxValue;

            return koef1;
        }
    }