<div align="center">

![Vectorial](https://img.shields.io/badge/Vectorial-Physics_Simulator-4A90E2?style=for-the-badge)
![Unity](https://img.shields.io/badge/Unity-Educational_Project-000000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Physics_Engine-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

</div>

# ⚡ Vectorial - Simulador de Cargas Eléctricas

<div align="center">

**An interactive 3D physics simulator for visualizing electric charges and electromagnetic fields**

[![Download Release](https://img.shields.io/badge/📥_DOWNLOAD-Latest_Release-4A90E2?style=for-the-badge)](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/releases)
[![University Project](https://img.shields.io/badge/🎓-University_Project-FFA500?style=for-the-badge)](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas)

[📝 Report Bug](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/issues) • [✨ Request Feature](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/issues)

</div>

---

## 📖 Descripción del Proyecto

**Vectorial** es un simulador educativo interactivo de física electromagnética desarrollado en Unity. Permite visualizar y experimentar con cargas eléctricas, campos eléctricos, fuerzas y vectores en tiempo real en un entorno 3D intuitivo.

### 🎯 Objetivo Educativo

Este proyecto fue desarrollado como parte de un proyecto universitario con el objetivo de:
- 📚 Facilitar el aprendizaje de física electromagnética
- 🔬 Visualizar conceptos abstractos de forma interactiva
- 🎮 Gamificar el aprendizaje de ciencias
- 🧪 Permitir experimentación sin riesgos

---

## ✨ Características Principales

### ⚡ Simulación Física
- 🔴 **Cargas Positivas y Negativas** - Crea y posiciona múltiples cargas
- 🧲 **Fuerzas Electromagnéticas** - Calcula fuerzas de Coulomb en tiempo real
- 📊 **Campos Vectoriales** - Visualización de campos eléctricos
- 📐 **Líneas de Campo** - Representación visual de líneas equipotenciales
- ⚙️ **Física Realista** - Simulación basada en leyes de electromagnetismo

### 🎮 Interactividad
- 🖱️ **Manipulación Directa** - Arrastra y posiciona cargas libremente
- 🎚️ **Control de Parámetros** - Ajusta magnitud de cargas
- 📹 **Cámara 3D** - Explora el espacio desde cualquier ángulo
- ⏸️ **Pausa y Reset** - Control total de la simulación
- 📈 **Datos en Tiempo Real** - Visualiza valores de fuerza y distancia

### 📚 Herramientas Educativas
- 📝 **Guías Interactivas** - Tutoriales paso a paso
- 🧮 **Fórmulas Visibles** - Ecuaciones de física aplicadas
- 📊 **Gráficos y Datos** - Análisis cuantitativo
- 💾 **Guardar Escenarios** - Guarda configuraciones para estudio

---

## 🎓 Conceptos Físicos Implementados

### Leyes y Principios

<div align="center">

| Concepto | Implementación |
|----------|----------------|
| **Ley de Coulomb** | F = k · (q₁ · q₂) / r² |
| **Campo Eléctrico** | E = F / q |
| **Superposición** | Campo total = Σ campos individuales |
| **Energía Potencial** | U = k · (q₁ · q₂) / r |

</div>

### 📐 Matemáticas Aplicadas
```
✅ Cálculo vectorial 3D
✅ Álgebra lineal
✅ Trigonometría
✅ Física computacional
✅ Métodos numéricos
```

---

## 🕹️ Controles

### 🖱️ Ratón
| Acción | Control |
|--------|---------|
| **Rotar Cámara** | Click Derecho + Arrastrar |
| **Mover Carga** | Click Izquierdo + Arrastrar |
| **Zoom** | Rueda del Ratón |
| **Seleccionar** | Click Izquierdo |

### ⌨️ Teclado
| Tecla | Función |
|-------|---------|
| **Espacio** | Pausar/Reanudar |
| **R** | Reset Simulación |
| **+/-** | Aumentar/Disminuir Carga |
| **Delete** | Eliminar Carga Seleccionada |
| **Tab** | Cambiar Modo de Visualización |

---

## 🛠️ Tecnologías Utilizadas

### Core Technologies
```csharp
🎮 Unity 2022+          // Motor de juego
💻 C#                  // Lenguaje de programación
🔢 Unity Physics       // Sistema de física
📊 Unity UI            // Interfaz de usuario
🎨 Shader Graph        // Visualización de campos
```

### Librerías y Herramientas
- **TextMesh Pro** - Texto de alta calidad
- **ProBuilder** - Modelado 3D en Unity
- **Cinemachine** - Sistema de cámaras
- **Custom Physics Engine** - Cálculos electromagnéticos

---

## 📁 Estructura del Proyecto

```
📁 Vectorial-Simulador-de-Cargas-Electricas/
├── 📂 Assets/
│   ├── 🎨 Materials/              # Materiales visuales
│   ├── 🎬 Prefabs/               # Prefabs de cargas y campos
│   ├── 📜 Scripts/               # Scripts de física y UI
│   │   ├── ChargeController.cs   # Control de cargas
│   │   ├── ElectricField.cs      # Cálculo de campos
│   │   ├── ForceCalculator.cs    # Ley de Coulomb
│   │   └── UIManager.cs          # Interfaz de usuario
│   ├── 🌅 Scenes/                # Escenas de Unity
│   └── 🔊 Audio/                 # Efectos de sonido
│
├── 📦 Vectorial_Release.7z       # Build ejecutable
├── 📜 LICENSE                    # Licencia MIT
└── 📄 README.md                  # Este archivo
```

---

## 🚀 Instalación y Uso

### 📥 Opción 1: Descargar Ejecutable (Recomendado)

1. **Descarga el simulador:**
   ```
   https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/blob/main/Vectorial_Release.7z
   ```

2. **Extrae el archivo `.7z`** usando 7-Zip o WinRAR

3. **Ejecuta `Vectorial. exe`**

4. **¡Empieza a experimentar! **

### 💻 Opción 2: Compilar desde Código Fuente

#### Requisitos Previos
- Unity 2022.3 LTS o superior
- Git
- 4GB de RAM mínimo

#### Pasos de Instalación

1. **Clonar el repositorio**
```bash
git clone https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas. git
cd Vectorial-Simulador-de-Cargas-Electricas
```

2. **Abrir en Unity Hub**
```
Unity Hub → Add → Selecciona la carpeta clonada
```

3. **Abrir escena principal**
```
Assets/Scenes/MainSimulation.unity
```

4. **Presiona Play ▶️**

---

## 📚 Guía de Uso

### 🔰 Primeros Pasos

1. **Crear una carga:**
   - Click derecho en el espacio → "Nueva Carga"
   - Selecciona positiva (+) o negativa (-)

2. **Posicionar cargas:**
   - Arrastra las cargas con el ratón
   - Usa las flechas del teclado para ajuste fino

3. **Observar interacciones:**
   - Las flechas rojas muestran fuerzas
   - Las líneas azules muestran campos eléctricos

4. **Modificar parámetros:**
   - Panel lateral → Ajusta magnitud de carga
   - Cambia constante de Coulomb (k)

### 🧪 Experimentos Sugeridos

<details>
<summary>📖 Experimento 1: Ley de Coulomb</summary>

**Objetivo:** Verificar la relación inversa del cuadrado de la distancia

1.  Coloca 2 cargas iguales a distancia `d`
2. Anota la fuerza `F1`
3. Duplica la distancia a `2d`
4. Anota la fuerza `F2`
5. Verifica que `F2 ≈ F1/4`

</details>

<details>
<summary>📖 Experimento 2: Superposición de Campos</summary>

**Objetivo:** Observar el principio de superposición

1. Coloca 3 cargas en triángulo equilátero
2. Añade una carga de prueba en el centro
3. Observa cómo los vectores se suman
4. Cambia signos y magnitudes

</details>

<details>
<summary>📖 Experimento 3: Líneas de Campo</summary>

**Objetivo:** Visualizar configuraciones clásicas

1. **Dipolo:** 1 carga + y 1 carga -
2. **Cuadrupolo:** 4 cargas alternadas
3. **Placa:** Múltiples cargas en línea

</details>

---

## 🎨 Capturas de Pantalla

> **📸 Añade capturas de pantalla aquí cuando estén disponibles**

```
[Screenshot 1: Interfaz principal]
[Screenshot 2: Simulación de dipolo]
[Screenshot 3: Visualización de campos]
[Screenshot 4: Panel de controles]
```

---

## 🎓 Contexto Académico

### 📋 Información del Proyecto

| Campo | Detalles |
|-------|----------|
| **Institución** | [Tu Universidad] |
| **Curso** | Física Electromagnética / Programación Científica |
| **Semestre** | [Año/Semestre] |
| **Autor** | Miventech (Jose Jaspe) |
| **Profesor/Tutor** | [Nombre si aplica] |

### 🎯 Objetivos de Aprendizaje Cubiertos

- ✅ Comprensión de la Ley de Coulomb
- ✅ Visualización de campos vectoriales
- ✅ Aplicación de física computacional
- ✅ Desarrollo de software educativo
- ✅ Programación orientada a objetos
- ✅ Integración de matemáticas y física

---

## 🔬 Física y Matemáticas

### ⚡ Ecuaciones Implementadas

#### Fuerza de Coulomb
```
F = k × (|q₁ × q₂|) / r²

Donde:
  F = Fuerza electromagnética (Newtons)
  k = Constante de Coulomb (8.99 × 10⁹ N·m²/C²)
  q₁, q₂ = Cargas eléctricas (Coulombs)
  r = Distancia entre cargas (metros)
```

#### Campo Eléctrico
```
E = k × q / r²

Donde: 
  E = Intensidad del campo eléctrico (N/C)
  q = Carga fuente (Coulombs)
  r = Distancia al punto (metros)
```

#### Energía Potencial
```
U = k × (q₁ × q₂) / r

Donde:
  U = Energía potencial eléctrica (Joules)
```

---

## 🛠️ Arquitectura Técnica

### 📐 Diseño de Sistemas

```csharp
// Ejemplo de estructura de código

public class Charge :  MonoBehaviour
{
    public float magnitude;  // Magnitud de la carga (C)
    public bool isPositive;  // Signo de la carga
    
    public Vector3 CalculateForce(Charge other)
    {
        // Implementación de Ley de Coulomb
        float k = 8.99e9f;
        Vector3 direction = other.transform.position - transform.position;
        float distance = direction.magnitude;
        
        float forceMagnitude = k * magnitude * other.magnitude / (distance * distance);
        return direction.normalized * forceMagnitude;
    }
}
```

### 🎯 Patrones de Diseño Utilizados

- 🏗️ **Singleton** - Gestor de simulación
- 🏭 **Factory** - Creación de cargas
- 👀 **Observer** - Actualización de UI
- 📋 **Command** - Sistema de deshacer/rehacer

---

## 📈 Roadmap y Mejoras Futuras

### ✅ Versión Actual (v1.0)
- [x] Simulación básica de cargas
- [x] Visualización de fuerzas
- [x] Interfaz de usuario
- [x] Controles de cámara
- [x] Sistema de pausa/reset

### 🔜 Próximas Versiones

#### v1.1 - Mejoras Visuales
- [ ] Partículas para campos eléctricos
- [ ] Mejores shaders para cargas
- [ ] Animaciones de transición
- [ ] Temas claro/oscuro

#### v1.2 - Nuevas Características
- [ ] Conductores y dieléctricos
- [ ] Capacitores
- [ ] Corrientes eléctricas
- [ ] Magnetismo

#### v2.0 - Expansión Mayor
- [ ] Modo VR
- [ ] Simulaciones pregrabadas
- [ ] Sistema de niveles/desafíos
- [ ] Exportar datos a CSV
- [ ] Integración con notebooks de Python

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si tienes ideas para mejorar el simulador: 

### Cómo Contribuir

1. **Fork el proyecto**
2. **Crea una rama** (`git checkout -b feature/MejorCaracteristica`)
3. **Commit tus cambios** (`git commit -m 'Añadir característica'`)
4. **Push a la rama** (`git push origin feature/MejorCaracteristica`)
5. **Abre un Pull Request**

### 🐛 Reportar Bugs

Si encuentras un bug, por favor abre un issue con: 
- Descripción del problema
- Pasos para reproducir
- Screenshots si es posible
- Información del sistema (OS, versión de Unity)

---

## 📚 Referencias y Bibliografía

### Libros
- Griffiths, D. J. - *Introduction to Electrodynamics*
- Purcell, E. M. - *Electricity and Magnetism*
- Feynman, R. P. - *The Feynman Lectures on Physics Vol. II*

### Recursos Online
- [Khan Academy - Electrostatics](https://www.khanacademy.org/science/physics/electric-charge-electric-force-and-voltage)
- [PhET Interactive Simulations](https://phet.colorado.edu/)
- [Unity Physics Documentation](https://docs.unity3d.com/Manual/PhysicsSection.html)

---

## 📜 Licencia

Este proyecto está bajo la **Licencia MIT**. Ver el archivo [LICENSE](LICENSE) para más detalles.

```
MIT License - Libre para usar, modificar y distribuir
```

---

## 👨‍💻 Autor

**Miventech** (Jose Jaspe)  
*Unity Developer & Physics Enthusiast*

<div align="center">

[![GitHub](https://img.shields.io/badge/GitHub-@miventech-181717?style=for-the-badge&logo=github)](https://github.com/miventech)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-Jose_Jaspe-0077B5?style=for-the-badge&logo=linkedin)](https://www.linkedin.com/in/jose-jaspe-miventech/)
[![YouTube](https://img.shields.io/badge/YouTube-@MiVenTech-FF0000?style=for-the-badge&logo=youtube)](https://www.youtube.com/@MiVenTech)
[![Itch.io](https://img.shields.io/badge/More_Games-Itch.io-FA5C5C?style=for-the-badge&logo=itch.io)](https://miventech.itch.io/)

</div>

---

## 🙏 Agradecimientos

- 🎓 **Profesores y tutores** por el apoyo académico
- 👥 **Compañeros de clase** por feedback y pruebas
- 🌐 **Comunidad de Unity** por tutoriales y recursos
- 📚 **PhET Colorado** por inspiración en simuladores educativos
- ☕ **Café** por mantenerme despierto durante el desarrollo

---

## 📞 Contacto y Soporte

¿Tienes preguntas o necesitas ayuda? 

- 📧 **Email:** [Tu email si quieres compartirlo]
- 💬 **Discord:** [Tu Discord si tienes]
- 🐛 **Issues:** [Abrir Issue](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/issues)
- 💡 **Discussions:** [GitHub Discussions](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/discussions)

---

<div align="center">

**⭐ Si este proyecto te fue útil para tus estudios, ¡dale una estrella!  ⭐**

[![GitHub Stars](https://img.shields.io/github/stars/miventech/Vectorial-Simulador-de-Cargas-Electricas?style=social)](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/miventech/Vectorial-Simulador-de-Cargas-Electricas?style=social)](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/network/members)

</div>

---

## 🎬 Videos y Tutoriales

<div align="center">

### 📺 Mira cómo funciona Vectorial

[![YouTube](https://img.shields.io/badge/Tutorial-YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white)](https://www.youtube.com/@MiVenTech)
[![TikTok](https://img.shields.io/badge/Demos-TikTok-000000?style=for-the-badge&logo=tiktok&logoColor=white)](https://www.tiktok.com/@miventech)

*¡Suscríbete para más contenido educativo de física y programación!*

</div>

---

<div align="center">

**Desarrollado con** ❤️ **y** ⚡ **por Miventech**

![Made with Unity](https://img.shields.io/badge/Made%20with-Unity-000000?style=flat&logo=unity&logoColor=white)
![Made with C#](https://img.shields.io/badge/Made%20with-C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![Educational](https://img.shields.io/badge/Purpose-Educational-FFA500?style=flat)

### 📥 Descarga Vectorial Ahora

[![Download](https://img.shields.io/badge/📥_DOWNLOAD-Vectorial_Simulator-4A90E2?style=for-the-badge)](https://github.com/miventech/Vectorial-Simulador-de-Cargas-Electricas/blob/main/Vectorial_Release.7z)

</div>

---

## 🌟 Características Destacadas

<div align="center">

| ⚡ Física Realista | 🎮 Interactivo | 📚 Educativo |
|:-----------------:|:-------------:|: ------------:|
| Cálculos precisos basados en leyes físicas | Manipulación directa de cargas | Perfecto para aprender |
| **🎨 Visual** | **💾 Portable** | **🆓 Gratis** |
| Gráficos 3D inmersivos | No requiere instalación | Open source y gratuito |

</div>
