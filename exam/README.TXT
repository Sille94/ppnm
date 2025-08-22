Practical Programning and Numerical Methods: Exam 2025

Generalised Eigenvalue Problem (GEV)

A. 
My implementation of og the GEV can be viewed in GEV.cs 

The objective is to ssolve AV = BVE, Where A is a real symmetric matix,  B is a real symmetric posetive definite matrix, V is the matrix of the generalized eigenvectors, and E is the diagonal matrix with the generalized eigen values. 

The system be solved via the diagonalization of B=QSQ^T. Q is optained via the jacobi eigenvalue algorythm implemented in EVD.cs from Homework 2. 
S is simply the diagonal matrix with the jacobi eigenvalues of B.

The GEV solver is tested by generating random two (n x n) matrices, where n={2,..,5}, which can be viewed in outA.txt

B. 
The code for the Hydrogen atom can be viewed in hydrogen.cs 

Using the variational method the basis functions for the hydrogen atom can be expressed as phi_i(r)=r*exp(-a_i*r^2)
where the wavequation u(r) = sum_{i=1,..,n}c_i*phi_i(r)

In order to solve the schoedinger equation the variational parameters a = {a_1,...,a_n} need to be found with minimization. For an intial guess of a the HN system is solved, and the ground state energy calculated. The optimized variational parameters minimize the gound state energy. I've used the minimization routine from Homework 9  

The coefficients c_i are found by solving Hc=eNc, using the routine from A. 

H and N are created in hydrogen.cs with the matrix elements
H[i,j] =3/2*Sqrt(PI)*a_i*a_j*(a_i+a_j)^{-5/2}-1/2*(a_i+a_j)^{-1}
N[i,j] =1/4*Sqrt(PI)*(a_i+a_j)^{-3/2}

The routine is executed with bases from n=1,...,5 and convergence is tested (see hydrogen_groundstate.svg)
The energy for the groundstate is expected to be around -0.5, the found values however are a litlle bit larger than that int the range [-0.2,0.26]. Howerver the basis set used are quite small so deviations should be expected. From the plot it is clear that the ground state energy is decreasing as n increases. It could be interesting to see if this tendency continous for larger n. 

C.  
My implementation for the GEV solver using Cholesky decompostion can be viewed in GEV.cs

Cholesky decomposition: B=L*L^t where L is a lower triangular matrix and L^t is its the conjugate transpose. 

Within this project B is real and herefore L^t=L^T. 

L is constructed using the following algorythm where

L[j,j] = Sqrt(B[j,j] - sum_{k=1,..,j-1}L[j,k]^2)
L[i,j] = 1/L[j,j](A[i,j] - sum_{k=1,..,j-1}L[i,k]*L[j,k])

In order to solve AV = BVE using the B=LL^t decomposition the following substituion is made. 

AV = LL^TVE, Let Y = L^TV, then V=(L^t)^{-1}Y, 

where (L^T)^{-1} is the inverse matrix of L^T, which is optained by using the inverse method implemented inthe QR factorization routine from Homework 2. 

using the above the system can be rewritten as

A(L^T)^{-1}Y = LL^t(L^t)^{-1}YE, L^T(L^T)^{-1}=I

L^{-1}A(L^T)^{-1}Y=YE, introducing Ã = L^{-1}A(L^T]^{-1}

we have ÃY=YE which is an ordenary symmetric eigenvalue problem, which is solved using the EVD routine. 

From this E is optained direclt, and V can be found by substituting Y back into V=(L^T)^{-1}Y.

The routine is tested in the same manner as the GEV routine from A. (see outC.txt) 


