using System.Collections;
using UnityEngine;

namespace Assets.Math
{
    public class TestMatrix : MonoBehaviour
    {
        private HMatrix2D matrix = new HMatrix2D();
        // Use this for initialization

        public bool question1A;
        public bool question2;
        
        void Start()
        {
            if(question1A)
            {
                Question1A();   
            }
            else if (question2)
            {
                Question2();
            }

        }

        private void Question1A()
        {
            matrix = new HMatrix2D();
            matrix.SetIdentity();
            matrix.Print();
        }

        private void Question2()
        {
            HMatrix2D mat1 = new HMatrix2D
                (1, 2, 1,
                0, 1, 0,
                2, 3, 4);
            HMatrix2D mat2 = new HMatrix2D
                (5, 6, 7,
                4, 1, 1,
                2, 3, 9);

            HMatrix2D mat3 = new HMatrix2D(
                new float[,] {
                {1 , 2 },
                {0 , 1 }
                }
                );

            HVector2D vector = new HVector2D(2, 6);

            //HVector2D answerVector = mat1 * vector;
            //answerVector.Print(); //will throw an error as it is not a 2 by 2 matrix

            HVector2D realAnswerVector = mat3 * vector;
            realAnswerVector.Print(); //works 

            HMatrix2D answerMatrix = mat1 * mat2;
            answerMatrix.Print(); //works

        }
    }
}